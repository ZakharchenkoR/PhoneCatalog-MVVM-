using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PhoneCatalog.Model;
using PhoneCatalog.Infrastructure;
using PhoneCatalog.View;
using System.Windows;

namespace PhoneCatalog.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        ILoader loader;
        ISaver saver;
        Filters filters;
        ObservableCollection<Phone> phones;
        Localisation localisationProp;
        int selectedStyle;
        int selectedLanguage;
        int selectedRAM = 0;
        int selectedMemory = 0;
        int selectedPrice = 0;
        int selectedManufacturer = 0;
        int selectedOS = 0;
        Phone selectedPhone;

        #region Properties

        public Localisation LocalisationProp
        {
            get => localisationProp;
            set
            {
                localisationProp = value;
                Notify();
            }
        }

        public ObservableCollection<Phone> Phones
        {
            get => phones;
            set
            {
                phones = value;
                Notify();
            }
        }

        public int SelectedOS
        {
            get => selectedOS;
            set
            {
                selectedOS = value;
                Phones = filters.Fitr(selectedRAM, selectedMemory, selectedPrice, selectedManufacturer, selectedOS);
                Phones = new ObservableCollection<Phone>(Phones);
                Notify();
            }
        }

        public int SelectedManufacturer
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                Phones = filters.Fitr(selectedRAM, selectedMemory, selectedPrice, selectedManufacturer,selectedOS);
                Phones = new ObservableCollection<Phone>(Phones);
                Notify();
            }
        }

        public int SelectedPrice
        {
            get => selectedPrice;
            set
            {
                selectedPrice = value;
                Phones = filters.Fitr(selectedRAM, selectedMemory, selectedPrice,selectedManufacturer,selectedOS);
                Phones = new ObservableCollection<Phone>(Phones);
                Notify();
            }
        }

        public int SelectedMemory
        {
            get => selectedMemory;
            set
            {
               
                selectedMemory = value;
                Phones = filters.Fitr(selectedRAM,selectedMemory,selectedPrice,selectedManufacturer,selectedOS);
                Phones = new ObservableCollection<Phone>(Phones);
                Notify();
            }
        }

        public int SelectedRAM
        {
            get => selectedRAM;
            set
            {
               
                
                selectedRAM = value;
                Phones = filters.Fitr(selectedRAM, selectedMemory,selectedPrice,selectedManufacturer,selectedOS);
                Phones = new ObservableCollection<Phone>(Phones);
                Notify();


                
            }
        }

        public int SelectedStyle 
        {
            get => selectedStyle;
            set
            {
                selectedStyle = value;
                Notify();
            }
        }

        public int SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                selectedLanguage = value;
               
                Notify();
            }
        }

        public Phone SelectedPhone
        {
            get => selectedPhone;
            set
            {
                selectedPhone = value;
                Notify();
            }
        }
        #endregion

        #region Commands
        public ICommand LoadStyle { get; set; }
        public ICommand SaveStyle { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand BlackStyleCommand { get; set; }
        public ICommand WhiteStyleCommand { get; set; }
        public ICommand NewPhoneCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ClosingCommand { get; set; }
        public ICommand LocCommand { get; set; }
        public ICommand SortManufacturer { get; set; }
        public ICommand SortRAM { get; set; }
        public ICommand SortPrice { get; set; }
        public ICommand SortMemory { get; set; }
        public ICommand SortOS { get; set; }
        public ICommand SortModel { get; set; }
        public ICommand SaveData { get; set; }
        public ICommand LoadData { get; set; }
        public ICommand ReturnFiltersCommand { get; set; }
        #endregion

        public MainViewModel(ISaver saver,ILoader loader,ISaverStyle saverStyle,ILoaderStyle loaderStyle )
        {
            this.loader = loader;
            this.saver = saver;
            filters = new Filters(loader);
            phones = Phone.GetPhones();
            LocalisationProp = new Localisation();
            LoadData = new RelayCommand(DataLoad);
            SaveData = new RelayCommand(x => saver.Save(Phones));
            SaveStyle = new RelayCommand(x => saverStyle.Save(SelectedStyle));
            LoadStyle = new RelayCommand(x => SelectedStyle = loaderStyle.Load());
            LoadCommand = new RelayCommand(Load);
            BlackStyleCommand = new RelayCommand(AddBlackStyle);
            WhiteStyleCommand = new RelayCommand(AddWhiteStyle);
            NewPhoneCommand = new RelayCommand(AddNewPhone);
            UpdateCommand = new RelayCommand(Update);
            CopyCommand = new RelayCommand(Copy);
            DeleteCommand = new RelayCommand(Delete);
            ClosingCommand = new RelayCommand(x => Application.Current.MainWindow.Close());
            LocCommand = new RelayCommand(Langusge);
            SortModel = new RelayCommand(ModelSort);
            SortManufacturer = new RelayCommand(ManufacturerSort);
            SortMemory = new RelayCommand(MemorySort);
            SortPrice = new RelayCommand(PriceSort);
            SortRAM = new RelayCommand(RAMSort);
            SortOS = new RelayCommand(OSSort);
            ReturnFiltersCommand = new RelayCommand(ReturnFilters);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #region Metods
        private void ReturnFilters (object a)
        {
            selectedPrice = 0;
            Phones = loader.Load();
            Phones = new ObservableCollection<Phone>(Phones);
        }

        private void DataLoad(object a)
        {
            Phones = loader.Load();
            Phones = new ObservableCollection<Phone>(Phones);
        }

        private void ModelSort(object a)
        {
            Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Model));
        }

        private void MemorySort(object a)
        {
            Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Memory));
        }

        private void RAMSort(object a)
        {
            Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.RAM));
        }

        private void PriceSort(object a)
        {
            Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Price));
        }

        private void OSSort(object a)
        {
            Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.OperatingSystem));
        }

        private void ManufacturerSort(object a)
        {
            Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Manufacturer));
        }

        private void Load(object a)
        {
            switch(SelectedStyle)
            {
                case 0:
                    ResourceDictionary dictionary = new ResourceDictionary();
                    dictionary.Source = new Uri("View/BlackStyle.xaml", UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries.Add(dictionary);
                    break;
                case 1:
                    ResourceDictionary dictionary2 = new ResourceDictionary();
                    dictionary2.Source = new Uri("View/WhiteStyle.xaml", UriKind.Relative);
                    Application.Current.Resources.MergedDictionaries.Add(dictionary2);
                    break;
            }
        }

        private void AddBlackStyle(object a)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("View/BlackStyle.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }

        public void AddWhiteStyle(object a)
        {
            ResourceDictionary dictionary2 = new ResourceDictionary();
            dictionary2.Source = new Uri("View/WhiteStyle.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dictionary2);
        }

        private void AddNewPhone(object a)
        {        
            Singleton singleton = Singleton.GetInstance();
            singleton.Loc = localisationProp;
            Window1 _window = new Window1();        
            singleton.Window = _window;
            _window.ShowDialog();
            Phones.Add(new Phone
            {
                Manufacturer = singleton.Manufacturer,
                Model = singleton.Model,
                OperatingSystem = singleton.OperatingSystem,
                Processor = singleton.Processor,
                RAM = singleton.RAM,
                Memory = singleton.Memory,
                Uri = singleton.Uri,
                Price = singleton.Price
            });
            Phones = new ObservableCollection<Phone>(Phones);
            saver.Save(Phones);
        }

        private void Update(object a)
        {
            if(SelectedPhone != null)
            {
                Singleton singleton = Singleton.GetInstance();
                singleton.Loc = LocalisationProp;
                singleton.Manufacturer = SelectedPhone.Manufacturer;
                singleton.Model = SelectedPhone.Model;
                singleton.OperatingSystem = SelectedPhone.OperatingSystem;
                singleton.Processor = SelectedPhone.Processor;
                singleton.RAM = SelectedPhone.RAM;
                singleton.Memory = SelectedPhone.Memory;
                singleton.Uri = SelectedPhone.Uri;
                singleton.Price = SelectedPhone.Price;
                WindowUpdate update = new WindowUpdate();
                singleton.WindowUpdate = update;
                update.ShowDialog();
                SelectedPhone.Manufacturer = singleton.Manufacturer;
                SelectedPhone.Model = singleton.Model;
                SelectedPhone.Memory = singleton.Memory;
                SelectedPhone.Processor = singleton.Processor;
                SelectedPhone.OperatingSystem = singleton.OperatingSystem;
                SelectedPhone.Price = singleton.Price;
                SelectedPhone.Uri = singleton.Uri;
                SelectedPhone.RAM = singleton.RAM;
                saver.Save(Phones);
                SelectedPhone = null;
            }
            else
            {
                if (SelectedLanguage == 0)
                {
                    MessageBox.Show("Select phone!");
                }
                else
                {
                    MessageBox.Show("Выберите телефон!");
                }
            }
        }

        private void Copy(object a)
        {
            if(selectedPhone != null)
            {
                Phones.Add(new Phone
                {
                    Manufacturer = SelectedPhone.Manufacturer,
                    Model = SelectedPhone.Model,
                    OperatingSystem = SelectedPhone.OperatingSystem,
                    Processor = SelectedPhone.Processor,
                    RAM = SelectedPhone.RAM,
                    Memory= SelectedPhone.Memory,
                    Price = SelectedPhone.Price,
                    Uri = SelectedPhone.Uri
                });
               Phones = new ObservableCollection<Phone>(Phones);
                saver.Save(Phones);
                SelectedPhone = null;
            }
            else
            {
                if(SelectedLanguage == 0)
                {
                    MessageBox.Show("Select phone!");
                }
                else
                {
                    MessageBox.Show("Выберите телефон!");
                }
            }
        }

        private void Delete(object a)
        {
            Phones.Remove(SelectedPhone);
            Phones = new ObservableCollection<Phone>(Phones);
            saver.Save(Phones);
        }


        private void Langusge(object a)
        {
            
            switch (SelectedLanguage)
            {
                case 0:
                    LocalisationProp.English = false;
                    LocalisationProp.LocalosationAdd();
                    Notify();
                    break;
                case 1:
                    LocalisationProp.English = true;
                    LocalisationProp.LocalosationAdd();
                    Notify();
                    break;
            }
        }
        #endregion

    }
}
