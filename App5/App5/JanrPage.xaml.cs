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
            GoToLoginForm();
        }

        private async void GoToLoginForm()
        {
            await Shell.Current.GoToAsync("//LoginForm");
        }
        private async void GetItemsToCollection()
        {
           collectionView.ItemsSource = await App.Database.GetJanrs();
        }


        private void collectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
           // if (collectionView.SelectedItem != null)
                Shell.Current.GoToAsync($"{nameof(JanrDetails)}?JanrId" +
                    $"{((Janr)collectionView.SelectedItem).Id}");
            //else
                //return;
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<Serial>();
            collectionView.ItemsSource = await App.Database.GetJanrs();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }
    }
}