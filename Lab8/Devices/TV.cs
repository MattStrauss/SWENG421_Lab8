using System;
using System.Collections.Generic;

namespace Lab8.Devices
{
    public class TV
    {
        public Dictionary<string, int> TVs = new Dictionary<string, int>() { {"Smart_TV", 200 }, {"UltraHD_TV", 300 }, { "Vizio_TV", 250 }, { "Vizio_Smart_TV", 350 }, 
            { "Vizio_UltraHD_TV", 450 }, { "Sony_TV", 280 }, { "Sony_Smart_TV", 380 }, { "Sony_UltraHD_TV", 480 } };

        private string _name;
        private int _price;

        public void SetPrice(int price)
        {
            _price = price;
        }
        public void SetName(string name)
        {
            _name = name;
        }

        int GetPrice()
        {
            return _price;
        }

        string _GetType()
        {
            if (this.GetType().Name.Contains("Smart")) {
                return "Smart";
            }else if (this.GetType().Name.Contains("Ultra"))
            {
                return "UltraHD";
            }
            else
            {
                return " Regular";
            }
        }

        public void GetInfo()
        {
            Console.WriteLine("With this budget, the best TV you can buy is: " + _name + ". You can get this powerful " + _GetType() + " TV for only: " + GetPrice() + "$");
        }

        public TV ReplenishTV(int budget)
        {
            var numerator = TVs.GetEnumerator();
            int difference;
            int min = int.MaxValue;
            string budgetTV = "";
            while (numerator.MoveNext())
            {
                difference = budget - numerator.Current.Value;
                if(difference < min && difference >= 0)
                {
                    min = difference;
                    budgetTV = numerator.Current.Key;
                }
            }
            if(min == int.MaxValue)
            {
                Console.WriteLine("Budget is too low to buy any TV");
                return null;
            }
            switch (budgetTV) {
                case ("Smart_TV"):
                    return new SmartTV();
                case ("UltraHD_TV"):
                    return new UltraHdTV();
                case ("Vizio_TV"):
                    return new VizioTV();
                case ("Vizio_Smart_TV"):
                    return new VizioSmartTV();
                case ("Vizio_UltraHD_TV"):
                    return new VizioUltraHdTV();
                case ("Sony_TV"):
                    return new SonyTV();
                case ("Sony_Smart_TV"):
                    return new SonySmartTV();
                case ("Sony_UltraHD_TV"):
                    return new SonyUltraHdTV();
                default:
                    return null;
            }

        }
    }

    public sealed class SmartTV : TV
    {
        private double _powerUsage;
        public SmartTV()
        {
            int price;
            string name = "Smart_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name); 
        }

        internal double GetPowerUsage()
        {
            return _powerUsage;
        }
    }

    public sealed class UltraHdTV : TV
    {
        public UltraHdTV()
        {
            int price;
            string name = "UltraHD_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name); 
        }
    }

    public interface ITV
    {    }

    public class ProxyTV : TV, ITV
    {
    }

    public abstract class BrandTV : TV, ITV
    {
        public abstract string GetBrand();
    }

    public interface ISmartTV : ITV
    {
        double GetPowerUsage();
    }


    public interface IUltraHdTV : ITV
    {

    }

    public class VizioTV : BrandTV
    {
        override
        public string GetBrand()
        {
            return "Vizio";
        }
        public VizioTV()
        {
            int price;
            string name = "Vizio_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name);
        }
    }

    public class SonyTV : BrandTV
    {
        override
        public string GetBrand()
        {
            return "Sony";
        }

        public SonyTV()
        {
            int price;
            string name = "Sony_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name); 
        }
    }

    public class VizioSmartTV : VizioTV, ISmartTV
    {
        public double GetPowerUsage()
        {
            return 6.35;
        }

        public VizioSmartTV()
        {
            int price;
            string name = "Vizio_Smart_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name); 
        }
    }

    public class VizioUltraHdTV : VizioTV, IUltraHdTV
    {
        public VizioUltraHdTV()
        {
            int price;
            string name = "Vizio_UltraHD_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name);
        }
    }

    public class SonySmartTV : SonyTV, ISmartTV
    {
        public double GetPowerUsage()
        {
            return 5.5;
        }
        public SonySmartTV()
        {
            int price;
            string name = "Sony_Smart_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name);
        }
    }

    public class SonyUltraHdTV : SonyTV, IUltraHdTV
    {
        public SonyUltraHdTV()
        {
            int price;
            string name = "Sony_UltraHD_TV";
            TVs.TryGetValue(name, out price);
            SetPrice(price);
            SetName(name);
        }
    }






}