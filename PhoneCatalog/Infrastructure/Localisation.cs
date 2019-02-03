using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Infrastructure
{
    class Localisation:INotifyPropertyChanged
    {
        private bool english = false;
        public string BlackStyle { get; set;}
        public string WhiteStyhle { get; set; }
        public string Engl { get; set; }
        public string RUS { get; set; }

        public bool English
        {
            get => english;
            set
            {
                english = value;
                Notify();
            }
        }

        public void LocalosationAdd()
        {
            if(English == true)
            {
                BlackStyle = "BlackStyle";
                WhiteStyhle = "WhiteStyle";
                Engl = "UK";
                RUS = "RUS";
            }
            else
            {
                BlackStyle = "Темный Стиль";
                WhiteStyhle = "Светлый Стиль";
                Engl = "АНГ";
                RUS = "Рус";
            }
        }
        public Localisation()
        {
            LocalosationAdd();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
