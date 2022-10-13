using System;

using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public Database Database { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Database = new Database();
            Navigation.PushAsync(new AppShell());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstPage(Database));
        }

        

    }
   
}