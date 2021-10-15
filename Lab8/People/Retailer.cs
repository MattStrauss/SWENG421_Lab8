using System;
using Lab8.Devices;

namespace Lab8.People
{
    class Retailer
    {
        private TV _TV = new TV();
        public TV ReplenishTV(int budget)
        {
            return _TV.ReplenishTV(budget);
        }
    }
}
