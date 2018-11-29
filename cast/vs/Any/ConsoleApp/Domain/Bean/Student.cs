using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Domain.Bean
{
    public class Student : Personal
    {
        public long ClassId { get; set; }

        public string School { get; set; }

        public int Post { get; set; }

    }
}