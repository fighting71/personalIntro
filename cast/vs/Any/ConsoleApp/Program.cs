using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                indexParam//最后一个expression 表示返回值
            );


            var expression = Expression.Lambda<Func<int>>(block);

            var info = expression.Compile()();

            Console.WriteLine(info);//11

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
                arrayExpr,//入参
                indexExpr,//入参
                valueExpr//最后一个表示返回值
            );// (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            Console.WriteLine(lambdaExpr.Compile().Invoke(new int[] { 10, 20, 30 }, 0, 5));

            //            GetNext();
            //            GetNext()();
            //            GetNext()()();
            //            GetNext()()()();

            Console.ReadKey();
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
            //
            //            var userInfos = list.AsQueryable().SqlWhere(((info) => info.Age > 18));
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