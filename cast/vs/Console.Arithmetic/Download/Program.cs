using System;
using System.Collections.Generic;
using System.Linq;

namespace Download
{

    class Info:IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(string obj)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string>();

            list.AddRange(new string[]{"234","asdfas","sjvosauidfio"});

        }
    }
}
