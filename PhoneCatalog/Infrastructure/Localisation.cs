using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Infrastructure
{
    class Localisation
    {
        public bool English { get; set; } = true;
        string b_style;

        public string BlackStyle
        { 
            set
            {
                if(English == true)
                {
                    b_style = "BlackStyle";
                }
                else
                {
                    b_style = "Чорная Тема";
                }
            }
        }
    }
}
