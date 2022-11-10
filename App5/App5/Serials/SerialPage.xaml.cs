using App5.Serials;
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
       // Serial serial = new Serial();

        public SerialPage()
        {
            InitializeComponent();
            GetItemsToCollection();
        }

        private async void GetItemsToCollection()
        {
            collectionView.ItemsSource = await App.Database.GetSerials();
        }

        private async void collectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                // await Shell.Current.GoToAsync($"{nameof(SerialDetails)}?{nameof(SerialDetails.SerialId)}={serial.Id}");
                 await Shell.Current.GoToAsync($"{nameof(SerialDetails)}?SerialId={((Serial)collectionView.SelectedItem).Id}");
            }
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