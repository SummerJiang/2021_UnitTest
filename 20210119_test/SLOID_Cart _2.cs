using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace SLOID_CartTest_2
{
    //public abstract class Cart
    //{
    //    public abstract double shippingFee(string shipper, double length, double width, double height, double weight)
    //    {
    //        double fee = 0;
    //        switch (shipper)
    //        { 
    //            case "black cat":
    //                BlackCat bc = new BlackCat();
    //                fee = bc.shippingFee();
    //                break;
    //            case "hsinchu":
    //                Hsinchu hc = new Hsinchu();
    //                fee = hc.shippingFee();
    //                break;
    //            case "post office":
    //                Hsinchu po = new Hsinchu();
    //                fee = po.shippingFee();
    //                break;
    //            default:
    //                throw new ArgumentException("shipper not exist");
    //        }
    //        return fee;

    //    }
     
    //}
    //public class BlackCat : Cart
    //{
    //    public override double shippingFee(string shipper, double length, double width, double height, double weight)
    //    {
    //        if (weight > 20)
    //            return 00;
    //        else
    //            return 100 + weight * 10;
    //    }
    //}

    //class Hsinchu : Cart
    //{
    //    public override double shippingFee(string shipper, double length, double width, double height, double weight)
    //    {
    //        double size = length * width * height;
    //        if (length > 100 || width > 100 || height > 100)
    //            return size * 0.00002 * 1100 + 500;
    //        else
    //            return size * 0.00002 * 1200;
    //    }
    //}

    //class Postoffice : Cart
    //{
    //    public override double shippingFee(string shipper, double length, double width, double height, double weight)
    //    {
    //        double feeByWeight = 80 + weight * 10;
    //        double size = length * width * height;
    //        double feeBySize = size * 0.00002 * 1100;
    //        return feeByWeight < feeBySize ? feeByWeight : feeBySize;
    //    }



    //}

}
