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
            int[] expected = { 700, 1220, 1390 };//4筆
           
            Assert.AreEqual(expected, orders.HiSelect(order => order.Price ,4));
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
            int[] expected = {63,162,261,109 };//3筆

            Assert.AreEqual(expected, orders.HiSelect(order => order.Cost, 3));
        }


        [Test]
        public void InuputWrongCount_OutputErrorMSG()
        {
            IList<int> Sumlist = new List<int>();

           
            
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
        public static IEnumerable HiSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector,int number)
        {
            IList<int> Sumlist = new List<int>();
            IList<int> Olist = new List<int>();

            foreach (var s in source)
            {
                Olist.Add(selector(s).GetHashCode());
            }

            if (Olist.Count > 0)
            {
                for (int data = 0; data < Olist.Count; data++) //來源資料筆數
                {
                    int sum = 0;
                    for (int i = 0; i < number && data < Olist.Count; i++) //分群數量
                    {
                        sum = sum + Olist[data];
                        data++;
                    }
                    data--; //資料會多加一筆需扣回，才能計算正確
                    Sumlist.Add(sum);
                }
            }

            return Sumlist;

        }
    }
}