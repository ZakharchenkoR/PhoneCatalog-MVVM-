using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Model
{
    class JSONLoader : ILoader
    {
        public ObservableCollection<Phone> Load()
        {
            if (File.Exists("DataPhones.json"))
            {
                ObservableCollection<Phone> phones = new ObservableCollection<Phone>();
                return phones = JsonConvert.DeserializeObject<ObservableCollection<Phone>>(File.ReadAllText("DataPhones.json"));

            }
            return null;
        }
    }
}
