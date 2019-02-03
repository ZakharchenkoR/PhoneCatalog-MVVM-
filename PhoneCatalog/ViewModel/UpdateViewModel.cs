using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using PhoneCatalog.Infrastructure;

namespace PhoneCatalog.ViewModel
{
    class UpdateViewModel : INotifyPropertyChanged
    {
        Localisation loc;
        Singleton singleton;
        string manufacturer;
        string model;
        string operaringSystem;
        string processor;
        int ram;
        int memory;
        int price;
        string uri;


        #region Propertys

        public Localisation Localisation
        {
            get => loc;
            set
            {
                loc = value;
                Notify();
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value;
                Notify();
            }
        }
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
        public ICommand AddPicturesCommand { get; set; }

        public UpdateViewModel()
        {
            singleton = Singleton.GetInstance();
            loc = singleton.Loc;
            Manufacturer = singleton.Manufacturer;
            Model = singleton.Model;
            OperatingSystem = singleton.OperatingSystem;
            Processor = singleton.Processor;
            RAM = singleton.RAM;
            Memory = singleton.Memory;
            Price = singleton.Price;
            Uri = singleton.Uri;
            UpdateCommand = new RelayCommand(Update);
            AddPicturesCommand = new RelayCommand(NewPicture);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void Update(object a)
        {
            singleton.Manufacturer = this.Manufacturer;
            singleton.Model = this.Model;
            singleton.Processor = this.Processor;
            singleton.OperatingSystem = this.OperatingSystem;
            singleton.Price = this.Price;
            singleton.Uri = this.Uri;
            singleton.Memory = this.Memory;
            singleton.RAM = this.RAM;
            singleton.WindowUpdate.Close();
        }

        private void NewPicture(object a)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Pictures(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                Uri = myDialog.FileName;
                Notify();
            }
        }
    }
}
