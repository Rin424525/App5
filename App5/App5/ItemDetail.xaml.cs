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
    public partial class ItemDetail : ContentPage
    {
        public Database Database { get; set; }
        public Item Item { get; set; }

        public ItemDetail(Database database, Item item)
        {
            InitializeComponent();
            Database = database;
            entryName.Text = item.Name;
            Item = item;
        }

        private async void Button_Save(object sender,EventArgs e)
        {
            Item.Name = entryName.Text;
            await Database.EditItem(Item);
            await Navigation.PopAsync();
        }


        private async void Button_Dell(object sender, EventArgs e)
        {
            Item.Name = entryName.Text;
            await Database.DeleteItem(Item);
            await Navigation.PopAsync();
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Item newItem = new Item { Name = entryName.Text };
            await Database.AddItem(newItem);
            await Navigation.PopAsync();
        }
    }
}