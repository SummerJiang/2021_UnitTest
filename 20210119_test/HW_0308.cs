using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HW_0308_Test
{
    public class HW0308Test
    {

        [Test]
        public void Inuput4PriceGroup_OutputTotalPrice()
        {
            var orders = new List<Order>
            {
                new Order {Cost = 10, Price = 130},
                new Order {Cost = 21, Price = 150},
                new Order {Cost = 32, Price = 200},
                new Order {Cost = 43, Price = 220},
                new Order {Cost = 54, Price = 250},
                new Order {Cost = 65, Price = 260},
                new Order {Cost = 76, Price = 300},
                new Order {Cost = 87, Price = 410},
                new Order {Cost = 98, Price = 660},
                new Order {Cost = 109, Price = 730},
            };
            int[] expected = { 700, 1220, 1390 };//4個群組
            Assert.AreEqual(expected, orders.GroupSum(order => order.Price ,4));
        }

        [Test]
        public void Inuput3CostGroup_OutputTotalCost()
        {
            var orders = new List<Order>
            {
                new Order {Cost = 10, Price = 130},
                new Order {Cost = 21, Price = 150},
                new Order {Cost = 32, Price = 200},
                new Order {Cost = 43, Price = 220},
                new Order {Cost = 54, Price = 250},
                new Order {Cost = 65, Price = 260},
                new Order {Cost = 76, Price = 300},
                new Order {Cost = 87, Price = 410},
                new Order {Cost = 98, Price = 660},
                new Order {Cost = 109, Price = 730},
            };
            int[] expected = {63,162,261,109 };//3個群組
            Assert.AreEqual(expected, orders.GroupSum(order => order.Cost, 3));
        }

        [Test]
        public void InuputWrongCount_OutputErrorMSG()
        {
            var orders = new List<Order>();

            Assert.Throws<ArgumentException>(() => orders.GroupSum(order => order.Cost, 3));
        }
       
    }

    public struct Order
    {
        public int Cost { get; set; }
        public int Price { get; set; }
    }

    public static class MySelect
    {
        //number為幾個為一組
        public static IEnumerable GroupSum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector,int number) 
        {
            IList<int> sumlist = new List<int>();//總數清單
            IList<int> olist = new List<int>();  //原始資料清單

            foreach (var s in source)
            {
                olist.Add(selector(s).GetHashCode());
            }

            if (olist.Count > 0)
            {
                //來源資料筆數
                for (int data = 0; data < olist.Count; data++) 
                {
                    int sum = 0;
                    //分群數量
                    for (int i = 0; i < number && data < olist.Count; i++) 
                    {
                        sum = sum + olist[data];
                        data++;
                    }
                    //來源資料會多加一筆需扣回，才能計算正確
                    data--; 
                    sumlist.Add(sum);
                }
            }
            else
                throw new ArgumentException("資料筆數為0", "專案HW_0308");

            return sumlist;

        }
    }
}