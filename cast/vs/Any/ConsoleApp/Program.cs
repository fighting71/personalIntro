using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ConsoleApp.Domain.Bean;
using ConsoleApp.Domain.Dto;
using ConsoleApp.Entity;
using ConsoleApp.Extension;
using ConsoleApp.Helper;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //AutoMapper的使用

            //博文:http://www.cnblogs.com/xishuai/p/3700052.html 
            //引用:AutoMapper 8.0
            //注:博文与此处使用的环境不一样

            Random random = new Random();

            //instance method register
//            var config = new MapperConfiguration(cfg => {
//                cfg.AddProfile<AppProfile>();
//                cfg.CreateMap<Source, Dest>();
//            });
//
//            var mapper = config.CreateMapper();
//            // or
//            IMapper mapper = new Mapper(config);
//            var dest = mapper.Map<Source, Dest>(new Source());

            //static method register
            Mapper.Initialize((cfg) =>
            {

                //step1:相同属性复制
//                IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();
                cfg.CreateMap<OrderInfo, OrderInfoDto>();
                //step1.2: 大小写不同 复制
                //AutoMapper在做解析的时候会按照PascalCase（帕斯卡命名法），就是一种变量命名法，除了PascalCase还有Hungarian（匈牙利命名法）和camelCase（骆驼命名法）
                //PascalCase就是指混合使用大小写字母来构成变量和函数的名字，首字母要大写，camelCase首字母小写，我们C#命名中，一般使用的是camelCase和PascalCase，比较高级的是PascalCase。
                cfg.CreateMap<OrderInfo, OrderInfoDataDto>();

                //step2: 属性不同 
                //IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>(MemberList memberList);
                //None.不影响
                //Destination.匹配所有dto的属性
                //Source.匹配所有source的属性
                //测试后发现无实用 鸡肋参数=-=
                //cfg.CreateMap<OrderInfo, OrderInfoShowDto>(MemberList.Destination);

                //step2.2: 映射属性名不同却相关的属性
                cfg.CreateMap<OrderInfo, OrderInfoShowDto>()
                    .ForMember((dto => dto.Hour), //dto关联
                        (expression => expression.MapFrom((orderInfo => orderInfo.CreateDateTime.Hour))) //source关系
                    );

//                cfg.CreateMap<OrderInfo, OrderEmptyDto>()
//                    .ForMember((dto => dto.Name),//dto关联
//                        (expression => expression.Ignore())//忽悠无关系的属性  此版本无需考虑
//                    );

                //step3: 抽象映射
                cfg.CreateMap<Personal, PersonalDto>()
                    .Include<Student, StudentDto>();

//                cfg.CreateMap<Personal, PersonalDto>();//重复创建--》覆盖

                cfg.CreateMap<Student, StudentDto>();

                //step4: 复杂映射
                cfg.CreateMap<Teacher, TeacherDto>().ForMember(
                    (dto => dto.BookDto), (expression => expression.MapFrom((teacher => teacher.Book))));
                cfg.CreateMap<Book, BookDto>();//nice 无需其他配置 挺人性化的 

                //step5: extension

//                cfg.CreateMissingTypeMaps = true;//DynamicMap

            });

            //验证类型映射是否正确
            Mapper.AssertConfigurationIsValid();

            //            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderInfo, OrderInfoDto>());

            var info = new OrderInfo()
            {
                OrderId = Guid.NewGuid().ToString(),
                ProductId = 1234,
                Remark = nameof(string.Empty),
                CreateDateTime = DateTime.Now
            };

            var orderInfoDto = Mapper.Map<OrderInfo, OrderInfoDto>(info);

            Console.WriteLine(JsonConvert.SerializeObject(orderInfoDto)); //success

            var orderInfoDataDto = Mapper.Map<OrderInfo, OrderInfoDataDto>(info);

            Console.WriteLine(JsonConvert.SerializeObject(orderInfoDataDto)); //success

            var orderInfoShowDto = Mapper.Map<OrderInfo, OrderInfoShowDto>(info);

            Console.WriteLine(JsonConvert.SerializeObject(orderInfoShowDto)); //success

            IList<OrderInfo> list = new List<OrderInfo>();

            list.Add(new OrderInfo()
            {
                OrderId = Guid.NewGuid().ToString(),
                ProductId = random.Next(10000),
                Remark = nameof(string.Empty),
                CreateDateTime = DateTime.Now
            });
            list.Add(new OrderInfo()
            {
                OrderId = Guid.NewGuid().ToString(),
                ProductId = random.Next(10000),
                Remark = nameof(string.Empty),
                CreateDateTime = DateTime.Now
            });
            list.Add(new OrderInfo()
            {
                OrderId = Guid.NewGuid().ToString(),
                ProductId = random.Next(10000),
                Remark = nameof(string.Empty),
                CreateDateTime = DateTime.Now
            });

//            var orderInfoShowDtos = Mapper.Map<IList<OrderInfo>,IList<OrderEmptyDto>>(list);
            var orderInfoShowDtos = Mapper.Map<IList<OrderInfoShowDto>>(list); //autoMapper 会自动检索source 故 TSource可忽略

            Console.WriteLine(JsonConvert.SerializeObject(orderInfoShowDtos));

            var personalDtos = Mapper.Map<List<PersonalDto>>(new []
            {
                new Personal()
                {
                    Age = random.Next(100),
                    Name = "monster",
                    Sex = 0
                },
                new Student()
                {
                    Age = random.Next(100),
                    Name = "monster",
                    Sex = 1,
                    ClassId = 187,
                    Post = 2,
                    School = "天空之城"
                },
            });

            foreach (var item in personalDtos)
            {
                Console.WriteLine(item.GetType());
            }

            var teacherDto = Mapper.Map<Teacher, TeacherDto>(new Teacher()
            {
                Age = random.Next(70) + 20,
                Name = "ms.Wang",
                Post = 3,
                Sex = random.Next(2),
                Book = new Book()
                {
                    Name = "天凉好个秋"
                }
            },(options =>
            {
                options.BeforeMap(((teacher, dto) =>
                {
                    Console.WriteLine("before map");
                }));
                options.AfterMap(((teacher, dto) =>
                {
                    Console.WriteLine("after map");
                }));
            }));

            Console.WriteLine(JsonConvert.SerializeObject(teacherDto));

            //---------------------over~
            //---------------------extension~

            //use method:
            //            var cfg = new MapperConfigurationExpression();
            //            cfg.CreateMap<Source, Dest>();
            //            cfg.AddProfile<MyProfile>();
            //            var mapperConfig = new MapperConfiguration(cfg);
            //            IMapper mapper = new Mapper(mapperConfig);

            //            Mapper.Initialize(cfg => cfg.CreateMissingTypeMaps = true);

            //            dynamic empty = new {Name = "empty"};
            //
            //            Book book = Mapper.Map<Book, dynamic>(empty);//error
            //
            //            Console.WriteLine(book.Name);

            Console.ReadKey(true);
        }

        static void TestBug(string[] args)
        {
            //如何解决ConcurrentModificationException? 多线程对共有资源进行读取  读时却存在写入 写入后读取还未进行完毕 
            //remark:java中存在,C#没发现存在...

            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            ThreadPool.QueueUserWorkItem((state =>
            {
                Console.WriteLine("开始添加元素");
                for (int i = 0; i < 1000000; i++)
                {
                    dictionary.Add(i, "empty");
                }

                Console.WriteLine("添加元素完毕");
            }));

//            ThreadPool.QueueUserWorkItem((state =>
//            {
//                Thread.Sleep(10);
//                Console.WriteLine("开始删除元素");
//                for (int i = 0; i < 1000000; i++)
//                {
//                    dictionary.Remove(i);//error --> 数组越界 
//                }
//
//                Console.WriteLine("删除元素完毕");
//            }));

            Thread.Sleep(10);

            #region 常见场景 --> error

//            Console.WriteLine("当前元素数量：" + dictionary.Count);
//
//            foreach (var item in dictionary.Keys)//System.InvalidOperationException:“Collection was modified; enumeration operation may not execute.”
//            {
//                Console.WriteLine(item);
//            }
//
//            Console.WriteLine("遍历输出元素完毕");

            #endregion

            Console.WriteLine("开始复制元素");
            Dictionary<int, string>
                dictionary2 = new Dictionary<int, string>(dictionary); //... .net core 优化了？ framework 中还是遍历来着 竟然不会报错。，
            Console.WriteLine("元素复制完毕：" + dictionary2.Count);

            Console.WriteLine("Complete");

            Console.ReadKey();
        }

        public static void TestExpression()
        {
            List<UserInfo> list = new List<UserInfo>();
            list.Add(new UserInfo());
            list.Add(new UserInfo());
            list.Add(new UserInfo());

            Console.WriteLine(list);

            Action action = () => { Console.WriteLine($"{MethodBase.GetCurrentMethod()} invoke"); };

            action.Method.Invoke(action.Target, new object[0]);

            Console.ReadKey();

            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            LabelTarget target = Expression.Label();
            LabelTarget target2 = Expression.Label(typeof(int));

            var indexParam = Expression.Parameter(typeof(int), "index"); //类似于参数

            //等价于 ==>  区别：Variable 不允许 byRef  其他的 emm....

            /**
             *public static ParameterExpression Variable(Type type, string name)
             *{
             *    ContractUtils.RequiresNotNull(type, "type");
             *    if (type == typeof(void))
             *    {
             *        throw Error.ArgumentCannotBeOfTypeVoid();
             *    }
             *    if (type.IsByRef)
             *    {
             *        throw Error.TypeMustNotBeByRef();
             *    }
             *    return ParameterExpression.Make(type, name, false);
             *}
             * public static ParameterExpression Parameter(Type type, string name)
             *{
             *    ContractUtils.RequiresNotNull(type, "type");
             *    if (type == typeof(void))
             *    {
             *        throw Error.ArgumentCannotBeOfTypeVoid();
             *    }
             *    bool isByRef = type.IsByRef;
             *    if (isByRef)
             *    {
             *        type = type.GetElementType();
             *    }
             *    return ParameterExpression.Make(type, name, isByRef);
             *}
             *
             *
             *
             */

            indexParam = Expression.Variable(typeof(int), "index");

            Expression block = Expression.Block( //创建一个语句块
                new[] {indexParam}, //语句块的默认参数
                Expression.Assign(indexParam, Expression.Constant(1)), //赋值 index = 1

                //                Expression.Variable(typeof(int),"temp"),//variable 'temp' of type 'System.Int32' referenced from scope '', but it is not defined”
                Expression.Loop( //创建一个循环块
                    Expression.IfThenElse( //创建一个if(){}else{}块
                        Expression.LessThanOrEqual(indexParam, Expression.Constant(10)), //test()  验证部分

                        //ifTrue:
                        Expression.Block(
                            Expression.Call( //方法调用
                                null, //调用实例  静态为null
                                typeof(Console).GetMethod(nameof(Console.WriteLine),
                                    new[] {typeof(string)}) //调用方法 methodInfo
                                //error : 方法没找到时  System.Reflection.AmbiguousMatchException:“Ambiguous match found.”
                                , Expression.Constant("Hello")), //传递参数
                            //参数类型不一致时： System.ArgumentException:“Expression of type 'System.Int32' cannot be used for parameter of type 'System.String' of method 'Void WriteLine(System.String)'”
                            //                            Expression.AddAssign(indexParam,Expression.Constant(1)),//add赋值
                            Expression.PostIncrementAssign(indexParam) //递增+1
                        ),

                        //ifFalse
                        Expression.Break(target)), target
                ),
                indexParam //最后一个expression 表示返回值
            );


            var expression = Expression.Lambda<Func<int>>(block);

            var info = expression.Compile()();

            Console.WriteLine(info); //11

            //next:创建一个有入参的lambda

            //Demo
            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[]), "Array");

            ParameterExpression indexExpr = Expression.Parameter(typeof(int), "Index");

            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            Expression arrayAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexExpr
            );

            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                arrayExpr, //入参
                indexExpr, //入参
                valueExpr //入参
            ); // (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            Console.WriteLine(lambdaExpr.Compile().Invoke(new int[] {10, 20, 30}, 0, 5));

            var parameterExpression = Expression.Variable(typeof(int), "empty");
            var numExpression = Expression.Parameter(typeof(int), "num");

            Expression<Func<int, int>> lambda = Expression.Lambda<Func<int, int>>(
                //                Expression.Assign(parameterExpression, numExpression),//variable 'empty' of type 'System.Int32' referenced from scope '', but it is not defined
                //                Expression.Assign(numExpression, Expression.Constant(100)),//带有返回类型的expression
                numExpression, //带有返回类型的expression
                numExpression); //param... 参数列表

            Console.WriteLine(lambda.Compile()(105));

            //            GetNext();
            //            GetNext()();
            //            GetNext()()();
            //            GetNext()()()();

            var expression1 = Expression.Lambda<Func<int, int>>(Expression.Block(
                    new[] {parameterExpression}, //声明局部变量
                    Expression.Assign(parameterExpression, numExpression),
                    parameterExpression
                )
                , numExpression);

            Console.WriteLine(expression1.Compile()(110));

            var numParam = Expression.Parameter(typeof(int), "num");

            var instanceParam = Expression.Parameter(typeof(Program));

            var body = Expression.Block(new[] {instanceParam}, //若在此出申明传入参数 则会导致传入参数值被覆盖即重新初始化
                Expression.Assign(instanceParam,
                    Expression.New(typeof(Program).GetConstructor(new Type[0]))) //instance = new Program();
                ,
                Expression.Assign(numParam,
                    Expression.Call(instanceParam,
                        typeof(Program).GetMethod(nameof(GetRandNum)),
                        numParam) //num = instance.GetRandNum();
                )
                , numParam //return num
            );

            var lambda1 = Expression.Lambda<Func<int, int>>(body, numParam);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(lambda1.Compile()(10));
            }

            //error: Cannot bind to the target method because its signature or security transparency is not compatible with that of the delegate type.
            //fix up :使用非静态方法创建delegate时 需要传入对象实例

            var instance = new Program();

//            var methodInfo = typeof(Program).GetMethod(nameof(GetRandNum));

            var @delegate = typeof(Program).GetMethod(nameof(GetRandNum), new[] {typeof(int)})
                .CreateDelegate(typeof(Program.EmptyDeletage), instance);

            Console.WriteLine((@delegate as EmptyDeletage)(100));

            Console.WriteLine(@delegate.Method.Invoke(instance, new object[] {108}));

            //emm... 感觉差不多了 

//            internal static Delegate Compile(LambdaExpression lambda, DebugInfoGenerator debugInfoGenerator)
//            {
//                AnalyzedTree tree = AnalyzeLambda(ref lambda);
//                tree.DebugInfoGenerator = debugInfoGenerator;
//                LambdaCompiler compiler = new LambdaCompiler(tree, lambda);
//                compiler.EmitLambdaBody();
//                return compiler.CreateDelegate();
//            }

            AopMethod(
                (() => { Console.WriteLine($"{MethodBase.GetCurrentMethod()} call before"); }),
                (() => { Console.WriteLine($"{MethodBase.GetCurrentMethod()} call after"); }),
                (() => { Console.WriteLine($"{MethodBase.GetCurrentMethod()} call now"); })
            ).Compile()();

            Console.ReadKey();
        }

        public static Expression<Action> AopMethod(Action before, Action after, Action call)
        {
            var blockExpression = Expression.Block(
                Expression.Call(Expression.Constant(before.Target), before.Method),
                Expression.Call(Expression.Constant(call.Target), call.Method),
                Expression.Call(Expression.Constant(after.Target), after.Method)
            );

            Expression<Action> expression = Expression.Lambda<Action>(blockExpression);

            return expression;
        }

        public static Action AopMethod2(Action before, Action after, Action call)
        {
            return () =>
            {
                before();
                call();
                after();
            };
        }

        public delegate int EmptyDeletage(int num);

        public int GetRandNum(int num)
        {
            return new Random().Next(num);
        }

        public static Func<Func<Action>> GetNext()
        {
            return () => () => () => { };
        }

        public static void ShowRunTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            action.Invoke();

            stopwatch.Stop();

            Console.WriteLine($"total spend timer:{stopwatch.ElapsedMilliseconds}ms");
        }

        static void Test()
        {
//            List<UserInfo> list = new List<UserInfo>();
//            var userInfos = list.AsQueryable().Where(((info) => info.Age > 18));
            //
            //            Console.WriteLine(userInfos);

            //            (MethodInfo)MethodBase.GetCurrentMethod();//获取当前方法

            // 创建 loop表达式体来包含我们想要执行的代码块
            //Loop-->循环
            //public static LoopExpression Loop(Expression body);
            //            LoopExpression loop = Expression.Loop(
            //
            //                // public static MethodCallExpression Call(Expression instance, MethodInfo method, params Expression[] arguments);
            //                // 调用一个方法  param:实例(why is Expression),方法,参数
            //                Expression.Call(
            //                    null,
            //                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
            //                    Expression.Constant("Hello")//ConstantExpression 表示具有常数值的表达式
            //                    )
            //
            //            );
            //            
            //            // 创建一个代码块表达式包含我们上面创建的loop表达式
            //            BlockExpression block = Expression.Block(loop);
            //
            //            // 将我们上面的代码块表达式
            //            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            //            lambdaExpression.Compile().Invoke();


            //            ParameterExpression number = Expression.Parameter(typeof(int), "number");
            //
            //            BlockExpression myBlock = Expression.Block(
            //                new[] { number },
            //                Expression.Assign(number, Expression.Constant(2)),//num = 2
            //                Expression.AddAssign(number, Expression.Constant(6)),//num+=6
            //                Expression.DivideAssign(number, Expression.Constant(2)));//num/=2
            //
            //            Expression<Func<int>> myAction = Expression.Lambda<Func<int>>(myBlock);
            //            Console.WriteLine(myAction.Compile()());//4

            //            Action action = () =>
            //            {
            //                for (int i = 0; i < 10; i++)
            //                {
            //                    Console.WriteLine("Hello");
            //                }
            //            }; //Lambda表达式实际上是一个Expression Body。
            //
            LabelTarget labelBreak = Expression.Label();
            ParameterExpression loopIndex = Expression.Parameter(typeof(int), "index");

            BlockExpression block = Expression.Block(
                new[] {loopIndex}, //引入变量
                // 初始化loopIndex =1
                Expression.Assign(loopIndex, Expression.Constant(1)),
                Expression.Loop(
                    Expression.IfThenElse(
                        // if 的判断逻辑
                        Expression.LessThanOrEqual(loopIndex, Expression.Constant(10)),
                        // 判断逻辑通过的代码
                        Expression.Block(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] {typeof(string)}),
                                Expression.Constant("Hello")),
                            Expression.PostIncrementAssign(loopIndex)), //++
                        // 判断不通过的代码
                        Expression.Break(labelBreak)
                    ), labelBreak));

            // 将我们上面的代码块表达式
            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            Console.WriteLine(lambdaExpression.Body);
            lambdaExpression.Compile()();

            Console.ReadKey(true);
        }


        #region 图灵自动回复

        private static string baseUrl = "http://www.tuling123.com/openapi/api";

        public static Dictionary<string, string> infoData = new Dictionary<string, string>();

        public static string[] bots = new[] {"By--小坚", "By--小白", "By--反正不是本人"};

        public static void TestChat()
        {
            infoData.Add("key", "04f44290d4cf462aae8ac563ea7aac16");
            infoData.Add("info", "你好!");

            Console.WriteLine("__________Welcome to chatRoom__________");
            Console.WriteLine("__________If you want quit ,Please input 'exit'__________");

            //            Console.WriteLine("请输入您的用户名：");
            //            var userName = Console.ReadLine();

            //            var chat = Chat(userName);
            var chatTask = Chat();

            bool isContinue = true;

            chatTask.ContinueWith((task => { isContinue = false; }));

            while (isContinue)
            {
            }
        }


        static async Task Chat(string userName = "monster")
        {
            Random random = new Random();

            var chatCount = 0;

            var msg = string.Empty;

            while (true)
            {
                Console.WriteLine();
                if (chatCount == 0)
                {
                    Console.WriteLine("聊天开始,赶紧输入你想要对我说的话吧:");
                }
                else
                {
                    Console.WriteLine(">>>" + userName + ":");
                }

                Console.Write("    ");

                msg = Console.ReadLine();

                if (msg.Trim().Equals("exit"))
                {
                    break;
                }

                var result = await Talk(msg);

                var resultMsg = JsonConvert.DeserializeObject<dynamic>(result);

                Console.WriteLine($@">>>{bots[random.Next(bots.Length)]} 
    {resultMsg.text}");

                chatCount++;
            }

            Console.WriteLine($"这次聊天很愉快,我们一共聊了{chatCount}次");
        }

        static async Task<string> Talk(string msg = "")
        {
            infoData["info"] = msg;

            var httpPost = await ApiHelper.HttpPostJson(baseUrl, infoData, Encoding.UTF8);

            return httpPost;
        }

        #endregion
    }
}