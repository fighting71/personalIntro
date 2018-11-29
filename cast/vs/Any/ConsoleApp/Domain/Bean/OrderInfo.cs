using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Domain.Bean
{
    public class OrderInfo
    {

        public String OrderId { get; set; }

        public String Remark { get; set; }

        public int? ProductId { get; set; }

        public DateTime CreateDateTime { get; set; }

    }
}
