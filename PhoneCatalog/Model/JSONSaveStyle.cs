﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PhoneCatalog.Model
{
    class JSONSaveStyle : ISaverStyle
    {
        public void Save(int selectrdStyleNimber)
        {
            string style = JsonConvert.SerializeObject(selectrdStyleNimber);
            File.WriteAllText("style.json", style);
        }
    }
}
