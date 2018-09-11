using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Command.Tools;

namespace Command.Demo
{
    public class FileDemo
    {
        public StringBuilder ReflectText()
        {
            var type = typeof(File);

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Static | BindingFlags.Public);

            StringBuilder builder = new StringBuilder();

            foreach (var methodInfo in methodInfos)
            {
                builder.AppendLine(String.Format("public static {0} {1}({2})", methodInfo.ReturnType.Name,
                    methodInfo.Name,
                    string.Join(",", methodInfo.GetParameters().Select(u => u.ParameterType.ToString() + " param")))
                );
            }

            return builder;
        }

        public void Test(string txt)
        {
//            File类:
//            提供用于创建、复制、删除、移动和打开文件的静态方法，并协助创建 FileStream 对象。

            string suffix = "empty";

            string fileName = Guid.NewGuid().ToString();

            string path = string.Format("F:\\empty\\vs_data\\{0}.{1}", fileName, suffix);

            int bufferSize = 1024;

            string content = txt;

            CreateDemo(path, content, bufferSize);
        }

        private static void CreateDemo(string path, string content, int bufferSize)
        {
            var floder = path.Substring(0, path.LastIndexOf("\\"));

            if (!Directory.Exists(path))
            {
                var directoryInfo = Directory.CreateDirectory(path);
                Console.WriteLine(directoryInfo);
            }


            //1.创建
            //Creates or overwrites the specified file.
            //public static FileStream Create(string path);
            //public static FileStream Create(string path, int bufferSize);

            //bufferSize  
            //The number of bytes buffered for reads and writes to the file.
            //为读和写缓存的字节数

            //public static FileStream Create(string path, int bufferSize, FileOptions options);

            //不进行任何操作时效果相同

            //emm...  通过创建缓存区  可以增加读写的效率

            CommandTool.CountTime((() =>
            {
                using (FileStream fileStream = File.Create(path))
                {
                    var bytes = Encoding.UTF8.GetBytes(content);
                    fileStream.Write(bytes, 0, bytes.Length);
                }

                return "public static FileStream Create(string path);";
            }));


            CommandTool.CountTime((() =>
            {
                using (FileStream fileStream = File.Create(path + "-1", bufferSize))
                {
                    var bytes = Encoding.UTF8.GetBytes(content);
                    fileStream.Write(bytes, 0, bytes.Length);
                }

                return "public static FileStream Create(string path, int bufferSize);";
            }));

            //            Asynchronous = 1073741824, // 0x40000000  异步锁
            //            DeleteOnClose = 67108864, // 0x04000000  在关闭时删除
            //            Encrypted = 16384, // 0x00004000 存在拒绝访问
            //            None = 0,
            //            RandomAccess = 268435456, // 0x10000000
            //            SequentialScan = 134217728, // 0x08000000
            //            WriteThrough = -2147483648, // -0x80000000  不计入缓存,直接操作

            CommandTool.CountTime((() =>
            {
                using (FileStream fileStream = File.Create(path + "-2", bufferSize, FileOptions.WriteThrough))
                {
                    var bytes = Encoding.UTF8.GetBytes(content);
                    fileStream.Write(bytes, 0, bytes.Length);
                }

                return "public static FileStream Create(string path, int bufferSize, FileOptions options);";
            }));

            // public static StreamWriter CreateText(string path);
            //Creates or opens a file for writing UTF-8 encoded text. If the file already exists, its contents are overwritten.
            CommandTool.CountTime((() =>
            {
                using (StreamWriter fw = File.CreateText(path + "---"))
                {
                    fw.Write(content);
                }

                return "public static StreamWriter CreateText(string path);";
            }));
        }
    }
}