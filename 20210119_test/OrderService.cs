using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtractAndOverrideTest
{
    public class OrderService
    {
        private const string FilePath = @"C:\temp\xxx.csv";


        //把檔案中類型=Book，並把產品名稱、價格回傳。
        public ImmutableDictionary<string, int> GetTopBooksByOrders()
        {
            var orders = GetOrders();

            // only get orders of book
            var ordersOfBook =
                orders
                    .Where(x => x.Type == "Book")
                    .GroupBy(g => new { ProductName = g.ProductName })
                    .Select(s => new { ProductName = s.Key.ProductName, Price = s.Sum(x => x.Price) })
                    .OrderByDescending(o => o.Price)
                    .ToImmutableDictionary(d => d.ProductName, d => d.Price);

            return ordersOfBook;
        }   

        //讀檔案資料
        protected virtual List<Order> GetOrders()
        {
            var result = new List<Order>();
            using (var sr = new StreamReader(FilePath, Encoding.UTF8))
            {
                var rowCount = 0;

                while (sr.Peek() > -1)
                {
                    rowCount++;
                    var content = sr.ReadLine();
                    if (rowCount > 1)
                    {
                        var line = content?.Trim().Split(',');

                        result.Add(this.Mapping(line));
                    }
                }
            }
            return result;
        }
        internal class StubOrderService : OrderService
        {
            private List<Order> _orders = new List<Order>();
            

            // only for test project to set the return values
            internal void SetOrders(List<Order> orders)
            {
                this._orders = orders;
            }

            // return the stub values, isolated the File I/O of parsing csv file
            protected override List<Order> GetOrders()
            {
                return this._orders;
            }
        }

        private Order Mapping(IReadOnlyList<string> line)
        {
            var result = new Order
            {
                ProductName = line[0],
                Type = line[1],
                Price = Convert.ToInt32(line[2]),
                CustomerName = line[3]
            };

            return result;
        }
    }

    public class Order
    {
        public string ProductName { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string CustomerName { get; set; }
    }
}