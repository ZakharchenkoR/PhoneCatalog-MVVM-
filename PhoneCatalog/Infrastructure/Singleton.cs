using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCatalog.View;

namespace PhoneCatalog.Infrastructure
{
    class Singleton
    {
        public Window1 Window { get; set; }
        public WindowUpdate WindowUpdate { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string OperatingSystem { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; }
        public string Uri { get; set; }

        private Singleton() { }
        static Singleton instance;
        public static Singleton GetInstance()
        {
            return instance ?? (instance = new Singleton());
        }
    }
}
