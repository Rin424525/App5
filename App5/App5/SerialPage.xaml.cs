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
    public partial class SerialPage : ContentPage
    {
 
        public SerialPage()
        {
            InitializeComponent();
            GetItemsToCollection();
        }

        private async void GetItemsToCollection()
        {
            collectionView.ItemsSource = await App.Database.GetSerials();
        }

      
        private void collectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
                Shell.Current.GoToAsync($"{nameof(SerialDetails)}?SerialId" +
                    $"{((Serial)collectionView.SelectedItem).Id}");
            else
                return;

        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<Serial>();
            collectionView.ItemsSource = await App.Database.GetSerials();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }


    }
}