using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Model
{
    class Phone : INotifyPropertyChanged
    {
        string manufacturer;
        string model;
        string operaringSystem;
        string processor;
        int ram;
        int memory;
        int price;
        string uri;

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                manufacturer = value;
                Notify();
            }
        }
        public string Model
        {
            get => model;
            set
            {
                model = value;
                Notify();
            }
        }

        public string OperatingSystem
        {
            get => operaringSystem;
            set
            {
                operaringSystem = value;
                Notify();
            }
        }

        public string Processor
        {
            get => processor;
            set
            {
                processor = value;
                Notify();
            }
        }

        public int RAM
        {
            get => ram;
            set
            {
                ram = value;
                Notify();
            }
        }

        public int Memory
        {
            get => memory;
            set
            {
                memory = value;
                Notify();
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value;
            }
        }

        public string Uri
        {
            get => uri;
            set
            {
                uri = value;
                Notify();
            }
        }

        public static ObservableCollection<Phone> GetPhones()
        {
            return new ObservableCollection<Phone>
            {
                new Phone{Manufacturer = "Google",
                    Model = "Pixel 3XL",
                    operaringSystem = "Android",
                    Processor = "SnapDragon 845",
                    RAM = 5,Memory = 64,
                    Price = 12999,
                    Uri = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQy7LXLKld_lx93nndypfXrRNlbao6T1VVW7H4UxOaWWH2uyO9fbw"},
                new Phone{Manufacturer = "Apple",
                    Model = "IPhone X",
                    operaringSystem = "IOS",
                    Processor = "Apple A11",
                    RAM = 3,Memory = 128,
                    Price = 15999,
                    Uri = @"https://stylus.ua/thumbs/390x390/e1/6e/633464.jpeg"},
                 new Phone{Manufacturer = "Xiaomi",
                    Model = "Mi 8",
                    operaringSystem = "Android",
                    Processor = "SnapDragon 845",
                    RAM = 6,Memory = 128,
                    Price = 16999,
                    Uri = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9G66ScevYrFh_MW4P0PRU5qSL7OZDb7LZahctXvyMDRGit1ZF"},
                 new Phone{Manufacturer = "Xiaomi",
                    Model = "A2",
                    operaringSystem = "Android",
                    Processor = "SnapDragon 670",
                    RAM = 6,Memory = 128,
                    Price = 9999,
                    Uri = @"https://i.citrus.ua/imgcache/size_500/uploads/shop/3/1/312b7e0266579ad2607d5ef5a9faf665.jpg"},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
