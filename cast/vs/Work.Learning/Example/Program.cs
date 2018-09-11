using System;
using System.Collections.Generic;
using Command.Demo;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(IEnumerable<string>);

            Console.WriteLine(type);

            FileDemo demo = new FileDemo();

            var stringBuilder = demo.ReflectText();

            demo.Test(stringBuilder.ToString());

            Console.WriteLine("Success");

            Console.ReadKey(true);
        }
    }
}