using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Domain.Dto
{
    public class TeacherDto : PersonalDto
    {
        public int Post { get; set; }

        public BookDto BookDto { get; set; }
    }
}