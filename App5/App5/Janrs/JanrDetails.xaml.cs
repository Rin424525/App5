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

    [QueryProperty(nameof(IdJanr), nameof(IdJanr))]
    public partial class JanrDetails : ContentPage
    {     
        private int janrId;
        public int IdJanr
        {
            get => janrId;
            set
            {
                IdJanr = value;
                EntryName.Text = SelectedJanr.Name;
                //SetJanr();
                //if (IdJanr > 0)
                //{
                //    SelectedJanr = App.Database.GetJanr(IdJanr);
                //    EntryName.Text = SelectedJanr.Name;
                //}
            }
        }
       
        public Janr SelectedJanr { get; set; }

        public JanrDetails()
        {
            InitializeComponent();
        }

        private async void SetJanr()
        {
            await App.Database.GetJanr(IdJanr);
        }

        private async void Button_Save(object sender, EventArgs e)
        {
            SelectedJanr.Name = EntryName.Text;
            await App.Database.EditJanr(SelectedJanr);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Dell(object sender, EventArgs e)
        {
            SelectedJanr.Name = EntryName.Text;
            await App.Database.DeleteJanr(SelectedJanr);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Janr newJanr = new Janr { Name = EntryName.Text };
            await App.Database.AddJanr(newJanr);
            await Shell.Current.GoToAsync("..");
        }
    }
}