﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Infrastructure
{
    class Localisation:INotifyPropertyChanged
    {
        private bool english = true;

        #region Propertys
        string catalogP;
        public string CatalogP
        {
            get => catalogP;
            set
            {
                catalogP = value;
                Notify();
            }
        }

        string ollRAM;
        public string OLLRAM
        {
            get => ollRAM;
            set
            {
                ollRAM = value;
                Notify();
            }
        }


        string blackStyle;
        public string BlackStyle
        {
            get => blackStyle;
            set
            {
                blackStyle = value;
                Notify();
            }
        }

        string whiteStyhle;
        public string WhiteStyle
        {
            get => whiteStyhle;
            set
            {
                whiteStyhle = value;
                Notify();
            }
        }

        string engl;
        public string Engl
        {
            get => engl;
            set
            {
                engl = value;
                Notify();
            }
        }

        string rUS;
        public string RUS
        {
            get => rUS;
            set
            {
                rUS = value;
                Notify();
            }

        }

        public bool English
        {
            get => english;
            set
            {
                english = value;
                Notify();
            }
        }


        string manufacturer;
        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                manufacturer = value;
                Notify();
            }
        }

        string newFone;
        public string NewPhone
        {
            get => newFone;
            set
            {
                newFone = value;
                Notify();
            }
        }

        string update;
        public string Update
        {
            get => update;
            set
            {
                update = value;
                Notify();
            }
        }

        string copy;
        public string Copy
        {
            get => copy;
            set
            {
                copy = value;
                Notify();
            }
        }

        string sort;
        public string Sort
        {
            get => sort;
            set
            {
                sort = value;
                Notify();
            }
        }

        string model;
        public string Model
        {
            get => model;
            set
            {
                model = value;
                Notify();
            }
        }

        string price;
        public string Price
        {
            get => price;
            set
            {
                price = value;
                Notify();
            }
        }

        string ram;
        public string RAM
        {
            get => ram;
            set
            {
                ram = value;
                Notify();
            }
        }

        string memory;
        public string Memory
        {
            get => memory;
            set
            {
                memory = value;
                Notify();
            }
        }


        string os;
        public string OS
        {
            get => os;
            set
            {
                os = value;
                Notify();
            }
        }

        string catalog;
        public string Catalog
        {
            get => catalog;
            set
            {
                catalog = value;
                Notify();
            }
        }

        string processor;
        public string Processor
        {
            get => processor;
            set
            {
                processor = value;
                Notify();
            }
        }

        string save;
        public string Save
        {
            get => save;
            set
            {
                save = value;
                Notify();
            }
        }

        string exit;
        public string Exit
        {
            get => exit;
            set
            {
                exit = value;
                Notify();
            }
        }

        string pictures;
        public string Pictures
        {
            get => pictures;
            set
            {
                pictures = value;
                Notify();
            }
        }

        string cancel;
        public string Cancel
        {
            get => cancel;
            set
            {
                cancel = value;
                Notify();
            }
        }

        string filter;
        public string Filter
        {
            get => filter;
            set
            {
                filter = value;
                Notify();
            }
        }

        string delete;
        public string Delete
        {
            get => delete;
            set
            {
                delete = value;
                Notify();
            }
        }
        #endregion

        public void ENG()
                {

                    BlackStyle = "Black Style";
                    WhiteStyle = "White Style";
                    Engl = "ENG";
                    RUS = "RUS";
                    Manufacturer = "Manufacturer";
                    NewPhone = "Add New Phone";
                    Update = "Update";
                    Copy = "Copy";
                    Sort = "Sorting";
                    Model = "Model";
                    Price = "Price";
                    Memory = "Memory";
                    RAM = "RAM";
                    OS = "OS";
                    Catalog = "Catalog";
                    Exit = "Exit";
                    Save = "Save";
                    Processor = "Processor";
                    Pictures = "Pictures";
                    CatalogP = "Phones Catalog";
                    ollRAM = "Oll phones";
                    Cancel = "Cancel";
                    Filter = "Choose";
                    Delete = "Delete";
        }



        public void RU()
        {
            BlackStyle = "Темная тема";
            WhiteStyle = "Светлая тема";
            Engl = "АНГ";
            RUS = "Рус";
            Manufacturer = "Производитель";
            NewPhone = "Добавить Телефон";
            Update = "Обновить";
            Copy = "Скопировать";
            Sort = "Сортировки";
            Model = "Модель";
            Price = "Цена";
            Memory = "Память телефона";
            RAM = "Память оперативная";
            OS = "Операционная система";
            Catalog = "Каталог";
            Exit = "Выйти";
            Save = "Сохранить";
            Processor = "Процесор";
            Pictures = "Картинка";
            CatalogP = "Каталог Телефонов";
            ollRAM = "Все телефоны";
            Cancel = "Отменить";
            Filter = "Выбрать";
            Delete = "Удалить";
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
