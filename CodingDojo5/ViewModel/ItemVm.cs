﻿using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo5.ViewModel
{
    public class ItemVm:ViewModelBase
    {

        public string Description { get; set; }

        public string AgeRecom { get; set; }
        public BitmapImage Image { get; set; }
        public ObservableCollection<ItemVm> ItemsInCategory { get; set; }

        public ItemVm(string description, string ageRecom, BitmapImage image)
        {
            Description = description;
            AgeRecom = ageRecom;
            Image = image;
        }


        //singleton pattern
        public void AddItemToCategory(ItemVm item)
        {
            if (ItemsInCategory == null)
            {
                ItemsInCategory = new ObservableCollection<ItemVm>();
            }
            else
            {
                ItemsInCategory.Add(item);
            }
        }



    }
}