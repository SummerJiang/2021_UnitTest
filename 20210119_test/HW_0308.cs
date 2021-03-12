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
        public void Inuput4ItemGroup_OutputTotalPrice()
        {
            var orders = new List<Order>
            {
                //new Order {Cost = 10, Price = 130},
                //new Order {Cost = 21, Price = 150},
                new Order {Cost = 10, Price = 1},
                new Order {Cost = 21, Price = 2},
                new Order {Cost = 32, Price = 200},
                new Order {Cost = 43, Price = 220},
                //new Order {Cost = 54, Price = 250},
                //new Order {Cost = 65, Price = 260},
                //new Order {Cost = 76, Price = 300},
                //new Order {Cost = 87, Price = 410},
                //new Order {Cost = 98, Price = 660},
                //new Order {Cost = 109, Price = 730},
            };
            //int[] expected = { 700, 1220, 1390 };//4筆
            //int[] expected = { 130, 150,200,220 };//2筆
            //int[] expected = { 280, 420 };//2筆
            //int[] expected = { 260, 150 };3筆
            int[] expected = { 3, 420 };//2筆

            //int[] expected = { 1,2,200, 220 };//2筆
            Assert.AreEqual(expected, orders.HiSelect(order => order.Price ,2));
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
            IList<int> Sumlist = new List<int> ();
            IList<int> Olist = new List<int>();

            foreach (var s in source)
            {
                Olist.Add(selector(s).GetHashCode());
            }
            
            if (Olist.Count > 0)
            {
                for (int data = 0; data < Olist.Count; data++) //四筆
                {
                    int sum = 0;
                    for (int i = 0; i < number && data < Olist.Count; i++) //2個群組
                    {
                        sum = sum + Olist[data];
                        data++;
                    }
                    Sumlist.Add(sum);
                }
            }
           
            return Sumlist;
               
        }
    }
}