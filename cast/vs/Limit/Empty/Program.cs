using System;

namespace Empty
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

//            var data = @"{""status"":{""code"":0,""msg"":""操作成功""},""pageNo"":1,""pageSize"":10,""total"":2,""list"":[{""id"":506480788035584000,""prizeType"":40,""prizeParentType"":4,""quantity"":1,""targetId"":280,""targetValue"":null,""targetSource"":""product"",""status"":1,""expireTime"":null,""createTime"":1540796028000,""addressId"":506480786774880256,""productName"":""【大众理财顾问】2018年11期总第425期杂志"",""productImg"":""http://img.unifin.com.cn/banner/15407952505bd6ab72bee62.png"",""deliveryMethod"":1,""logisticsName"":null,""logisticsNo"":null},{""id"":506480833785311232,""prizeType"":40,""prizeParentType"":4,""quantity"":1,""targetId"":280,""targetValue"":null,""targetSource"":""product"",""status"":1,""expireTime"":null,""createTime"":1540796039000,""addressId"":506480833180659712,""productName"":""【大众理财顾问】2018年11期总第425期杂志"",""productImg"":""http://img.unifin.com.cn/banner/15407952505bd6ab72bee62.png"",""deliveryMethod"":1,""logisticsName"":null,""logisticsNo"":null}],""endIndex"":10,""startIndex"":0,""success"":true}";

            bool flag = !(GetFalse() || GetTrue());

            flag = GetFalse() && GetTrue();

            Console.ReadKey();
        }

        public static bool GetTrue()
        {
            Console.WriteLine(nameof(GetTrue));
            return true;
        }

        public static bool GetFalse()
        {
            Console.WriteLine(nameof(GetFalse));
            return false;
        }
    }
}