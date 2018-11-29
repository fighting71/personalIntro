using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Domain.Dto
{
    public class OrderInfoShowDto
    {

        public String OrderId { get; set; }

        public String Remark { get; set; }

        public int? ProductId { get; set; }

        public int Hour { get; set; }

    }
}
