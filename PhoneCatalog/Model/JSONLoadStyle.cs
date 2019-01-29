using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PhoneCatalog.Model
{
    class JSONLoadStyle : ILoaderStyle
    {
        public int Load()
        {
            if(File.Exists("style.json"))
            {
                return JsonConvert.DeserializeObject<int>(File.ReadAllText("style.json"));
            }
            return 0;
        }
    }
}
