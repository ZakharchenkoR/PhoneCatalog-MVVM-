using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PhoneCatalog.Model
{
    class JSONSaver : ISaver
    {
        public void Save(IEnumerable<Phone> phones)
        {
            string phone = JsonConvert.SerializeObject(phones);
            File.WriteAllText("DataPhones.json", phone);
        }
    }
}
