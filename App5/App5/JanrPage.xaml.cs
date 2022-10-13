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
        public Database Database { get; set; }
        public Janr Janr { get; set; }

        public JanrPage(Database database, Janr janr)
        {
            InitializeComponent();
            Database = database;
            entryName.Text = janr.Name;
            Janr = janr;
        }

        private async void Button_Save(object sender, EventArgs e)
        {
            Janr.Name = entryName.Text;
            await Database.EditJanr(Janr);
            await Navigation.PopAsync();
        }


        private async void Button_Dell(object sender, EventArgs e)
        {
            Janr.Name = entryName.Text;
            await Database.DeleteJanr(Janr);
            await Navigation.PopAsync();
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Janr newJanr = new Janr { Name = entryName.Text };
            await Database.AddJanr(newJanr);
            await Navigation.PopAsync();
        }
    }
}