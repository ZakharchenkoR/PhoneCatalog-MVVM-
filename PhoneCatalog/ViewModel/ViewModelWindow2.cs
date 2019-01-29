using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PhoneCatalog.Infrastructure;

namespace PhoneCatalog.ViewModel
{
    class ViewModelWindow2 : INotifyPropertyChanged
    {
        Singleton singleton = Singleton.GetInstance();
        string manufacturer;
        string model;
        string operaringSystem;
        string processor;
        int ram;
        int memory;
        string uri;
       

        #region Propertys
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

        public string Uri
        {
            get => uri;
            set
            {
                uri = value;
                Notify();
            }
        }
        #endregion

        public ICommand AddPhone { get; set; }

        public ViewModelWindow2()
        {        
            AddPhone = new RelayCommand(NewPhone);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void NewPhone(object a)
        {
            singleton.Manufacturer = this.Manufacturer;
            singleton.Model = this.Model;
            singleton.OperatingSystem = this.OperatingSystem;
            singleton.Processor = this.Processor;
            singleton.RAM = this.RAM;
            singleton.Memory = this.Memory;
            singleton.Uri = this.Uri;
            singleton.Window.Close();
        }
    }
}
