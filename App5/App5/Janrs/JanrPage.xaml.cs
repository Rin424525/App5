using App5.Janrs;
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
    public partial class JanrPage : ContentPage
    { 
        public JanrPage()
        {
            InitializeComponent();
            GetItemsToCollection();          
        }

        private async void GetItemsToCollection()
        {
           collectionView.ItemsSource = await App.Database.GetJanrs();
        }

        private async void collectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
                await Shell.Current.GoToAsync($"JanrDetails?{((Janr)collectionView.SelectedItem).Id}");
            //await Shell.Current.GoToAsync($"{nameof(JanrDetails)}?JanrId{((Janr)collectionView.SelectedItem).Id}");
            // await Shell.Current.GoToAsync($"{nameof(JanrDetails)}?{nameof(JanrDetails.IdJanr)}={((Janr)collectionView.SelectedItem).Id}");
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<Janr>();
            collectionView.ItemsSource = await App.Database.GetJanrs();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }
    }
}