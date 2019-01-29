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
    class UpdateViewModel : INotifyPropertyChanged
    {
        Singleton singleton;
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

        public ICommand  UpdateCommand {get; set; }
        public UpdateViewModel()
        {
            singleton = Singleton.GetInstance();
            manufacturer = singleton.Manufacturer;
            Model = singleton.Model;
            OperatingSystem = singleton.OperatingSystem;
            Processor = singleton.Processor;
            RAM = singleton.RAM;
            Memory = singleton.Memory;
            Uri = singleton.Uri;
            UpdateCommand = new RelayCommand(Update);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void Update(object a)
        {
            MessageBox.Show(singleton.Manufacturer);
        }
    }
}
