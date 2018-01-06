using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Media.Imaging;

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
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ItemVm> Category { get; set; }

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Category = new ObservableCollection<ItemVm>();
            GenerateDemoData();
        }
        
        private void GenerateDemoData()
        {
            //generate Categories
            Category.Add(new ItemVm("My LEGO", "", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative))));
            Category.Add(new ItemVm("My Playmobile", "", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative))));

            //Add lego items to category
            Category[0].AddItemToCategory(new ItemVm("Helicopter", "10+", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Digger", "12+", new BitmapImage(new Uri("Images/lego2.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Chain Loader", "14+", new BitmapImage(new Uri("Images/lego3.jpg", UriKind.Relative))));
            Category[0].AddItemToCategory(new ItemVm("Crawler Crane", "12+", new BitmapImage(new Uri("Images/lego4.jpg", UriKind.Relative))));
            
            //Add playmobile items to category
            Category[1].AddItemToCategory(new ItemVm("Beach House", "5+", new BitmapImage(new Uri("Images/playmobile1.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("House", "8+", new BitmapImage(new Uri("Images/playmobile2.jpg", UriKind.Relative))));
            Category[1].AddItemToCategory(new ItemVm("Knights", "8+", new BitmapImage(new Uri("Images/playmobile13.jpg", UriKind.Relative))));
        }
    }
}