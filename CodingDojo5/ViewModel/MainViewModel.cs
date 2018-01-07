using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.CommandWpf;

namespace CodingDojo5.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// 
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private ItemVm selectedCategory;

        public ItemVm SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                RaisePropertyChanged();
            }
        }


        private RelayCommand<ItemVm> buyBtnClickedCmd;

        public RelayCommand<ItemVm> BuyBtnClickedCmd
        {
            get
            {
                return buyBtnClickedCmd;
            }
            set
            {
                buyBtnClickedCmd = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<ItemVm> Category { get; set; }

        public ObservableCollection<ItemVm> Cart { get; set; }

        public MainViewModel()
        {

            Category = new ObservableCollection<ItemVm>();
            Cart = new ObservableCollection<ItemVm>();
            BuyBtnClickedCmd = new RelayCommand<ItemVm>((itemOfPurchase) => 
            {
                Cart.Add(itemOfPurchase);
                foreach (var item in Cart)
                {
                    Console.WriteLine(item.Description);
                }
            });

            GenerateDemoData();
        }

        private void GenerateDemoData()
        {
            //generate Categories
            Category.Add(new ItemVm("My LEGO", "", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative))));
            Category.Add(new ItemVm("My Playmobil", "", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative))));

            //Add lego items to category
            Category[0].AddItemToCategory(new ItemVm("Helicopter", "10+", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Digger", "12+", new BitmapImage(new Uri("Images/lego2.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Chain Loader", "14+", new BitmapImage(new Uri("Images/lego3.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Crawler Crane", "12+", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative))));

            //Add playmobile items to category
            Category[1].AddItemToCategory(new ItemVm("Beach House", "5+", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House", "8+", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("3 Knights", "8+", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House 1", "10+", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("5 Knights", "8+", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House 2", "12+", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("7 Knights", "8+", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative))));

            //Testitem for Cart
            //Cart.Add(new ItemVm("Crawler Crane", "12+", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative))));
            //Cart.Add(new ItemVm("Digger", "12+", new BitmapImage(new Uri("Images/lego2.jpg", UriKind.Relative))));
        }
    }
}