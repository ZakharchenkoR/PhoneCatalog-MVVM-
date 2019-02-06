using Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCatalog.Model;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace PhoneCatalog.Infrastructure
{
    class Filters
    { 
        ILoader loader;
        public Filters(ILoader loader)
        {
            this.loader = loader;
        }

       public ObservableCollection<Phone> Fitr(int selectedRAM,int selectedMemory,int selectedPrice,int selectedManufacturer,int selectrdOS)
        {
            ObservableCollection<Phone> phones = new ObservableCollection<Phone>();

            if (File.Exists("DataPhones.json"))
            {

               phones = JsonConvert.DeserializeObject<ObservableCollection<Phone>>(File.ReadAllText("DataPhones.json"));
            }

            if (selectedManufacturer == 0 && selectedMemory == 0 && selectedPrice == 0 && selectrdOS == 0 && selectedRAM == 0)
            {
                return phones;
            }

            if (selectrdOS != 0)
                {
                    switch (selectrdOS)
                    {
                        case 1:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.OperatingSystem == "IOS"));
                            break;
                        case 2:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.OperatingSystem == "Android"));
                            break;
                        case 3:
                            phones = new ObservableCollection<Phone>(phones.Where(x => (x.OperatingSystem != "Android") && x.OperatingSystem != "IOS"));
                            break;
                    }
                }

                if (selectedRAM != 0)
                {
                    switch (selectedRAM)
                    {

                        case 1:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.RAM == 1));
                            break;
                        case 2:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.RAM == 2));
                            break;
                        case 3:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.RAM == 3));
                            break;
                        case 4:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.RAM == 4));
                            break;
                        case 5:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.RAM == 6));
                            break;
                        case 6:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.RAM == 8));
                            break;
                    }
                }

                if (selectedManufacturer != 0)
                {
                    switch (selectedManufacturer)
                    {

                        case 1:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Manufacturer == "Apple"));
                            break;
                        case 2:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Manufacturer == "Samsung"));
                            break;
                        case 3:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Manufacturer == "Xiaomi"));
                            break;
                        case 4:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Manufacturer == "Huawei"));
                            break;
                        case 5:
                            phones = new ObservableCollection<Phone>(phones.Where(x => (x.Manufacturer != "Apple") &&
                            (x.Manufacturer != "Samsung") &&
                            (x.Manufacturer != "Xiaomi" &&
                            (x.Manufacturer != "Huawei"))));
                            break;
                    }
                }

                if (selectedPrice != 0)
                {
                    switch (selectedPrice)
                    {

                        case 1:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Price > 0 && x.Price <= 5000));
                            break;
                        case 2:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Price > 0 && x.Price <= 10000));
                            break;
                        case 3:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Price > 0 && x.Price <= 15000));
                            break;
                        case 4:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Price > 0 && x.Price <= 20000));
                            break;
                        case 5:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Price > 0 && x.Price <= 25000));
                            break;
                        case 6:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Price >= 25000));
                            break;
                    }
                }

                if (selectedMemory != 0)
                {
                    switch (selectedMemory)
                    {

                        case 1:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Memory == 8));
                            break;
                        case 2:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Memory == 16));
                            break;
                        case 3:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Memory == 32));
                            break;
                        case 4:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Memory == 64));
                            break;
                        case 5:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Memory == 128));
                            break;
                        case 6:
                            phones = new ObservableCollection<Phone>(phones.Where(x => x.Memory == 256));
                            break;
                    }
                }

            return phones;
        }
       
    }
}
