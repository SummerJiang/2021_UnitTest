using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace SLOID_CartTest
{
    public class Cart
    {
        public interface IshippingFee
        {
            double shippingFee(string shipper, double length, double width, double height, double weight);
        }

        public class BlackCat : IshippingFee
        {
            public double shippingFee(string shipper, double length, double width, double height, double weight)
            {
                if (weight > 20)
                    return 500;
                else
                    return 100 + weight * 10;
            }
        }

        public class Hsinchu : IshippingFee
        {
            public double shippingFee(string shipper, double length, double width, double height, double weight)
            {
                double size = length * width * height;
                if (length > 100 || width > 100 || height > 100)
                    return size * 0.00002 * 1100 + 500;
                else
                    return size * 0.00002 * 1200;
            }
        }

        public class Postoffice : IshippingFee
        {
            public double shippingFee(string shipper, double length, double width, double height, double weight)
            {
                double feeByWeight = 80 + weight * 10;
                double size = length * width * height;
                double feeBySize = size * 0.00002 * 1100;
                return feeByWeight < feeBySize ? feeByWeight : feeBySize;
            }
        }

        public class shippingFee
        {
            public static double BlackCat(string shipper, double length, double width, double height, double weight)
            {
                if (weight > 20)
                    return 500;
                else
                    return 100 + weight * 10;
            }

            public static double Hsinchu(string shipper, double length, double width, double height, double weight)
            {
                double size = length * width * height;
                if (length > 100 || width > 100 || height > 100)
                    return size * 0.00002 * 1100 + 500;
                else
                    return size * 0.00002 * 1200;
            }

            public static double Postoffice(string shipper, double length, double width, double height, double weight)
            {
                double feeByWeight = 80 + weight * 10;
                double size = length * width * height;
                double feeBySize = size * 0.00002 * 1100;
                return feeByWeight < feeBySize ? feeByWeight : feeBySize;
            }

          
        }
    }
}
