using System;

namespace Lab8
{

    public class Tv
    {
        private int _price;

        public void SetPrice(int price)
        {
            _price = price; 
        }

        public int GetPrice()
        {
            return _price; 
        }

        public string _GetType()
        {
            return "..."; 
        }
        

        public void GetInfo()
        {
            Console.WriteLine(GetPrice() + " " + _GetType() );
        }

        public Tv ReplenishTv(int budget)
        {
            return new Tv(); 
        }
    }

    public sealed class SmartTv : Tv
    {
        private double _powerUsage; 
        
        internal double GetPowerUsage()
        {
            return _powerUsage;
        }
    }

    public sealed class UltraHdTv : Tv
    {
        
    }
    
    public interface ITv
    {
        void SetPrice(int price);
        void GetInfo();
        int GetPrice();
        string _GetType();
        Tv ReplenishTv(int budget); 
    }

    public class ProxyTv : Tv, ITv
    {
        private Tv _tv = new Tv();
    }
    
    public abstract class BrandTv : Tv, ITv
    {
        public abstract string GetBrand();
    }
    
    public interface ISmartTv : ITv
    {
        double GetPowerUsage(); 
    }


    public interface IUltraHdTv : ITv
    {
        
    }
    
    public class VizioTv : BrandTv
    {
        override 
        public string GetBrand()
        {
            return "Vizio";
        }
    }

    public class SonyTv : BrandTv
    {
        override 
            public string GetBrand()
        {
            return "Sony";
        }
    }

    public class VizioSmartTv : VizioTv, ISmartTv
    {
        public double GetPowerUsage()
        {
            return 6.35;
        }
    }

    public class VizioUltraHdTv : VizioTv, IUltraHdTv
    {
        
    }

    public class SonySmartTv : SonyTv, ISmartTv
    {
        public double GetPowerUsage()
        {
            return 5.5;
        }
    }

    public class SonyUltraHdTv : SonyTv, IUltraHdTv
    {
        
    }


    public class Retailer
    {
        private Tv _tv = new Tv(); 
    }



    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}