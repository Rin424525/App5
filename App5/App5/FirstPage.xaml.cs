using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public Database Database { get; set; }
 
        public FirstPage(Database database)
        {
            InitializeComponent();
            Database = database;
            GetItemsToCollection();
        }

        private async void GetItemsToCollection()
        {
            collectionView.ItemsSource = await Database.GetItems();
        }

      
        private void collectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
                Navigation.PushAsync(new ItemDetail(Database, (Item)collectionView.SelectedItem));
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<Item>();
            collectionView.ItemsSource = await Database.GetItems();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }


    }
}