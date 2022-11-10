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

    [QueryProperty(nameof(JanrId), nameof(JanrId))]
    public partial class JanrDetails : ContentPage
    {
        public Janr Janr { get; set; }  
        private int janrId;      
        public int JanrId
        {
            get => janrId; set
            {
                JanrId = value;
                if (janrId != 0)
                {
                    SetJanr();
                }
            }
        }

        public JanrDetails()
        {
            InitializeComponent();
        }

        private async void SetJanr()
        {
            await App.Database.GetJanr(JanrId);
        }

        private async void Button_Save(object sender, EventArgs e)
        {
            Janr.Name = entryName.Text;
            await App.Database.EditJanr(Janr);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Dell(object sender, EventArgs e)
        {
            Janr.Name = entryName.Text;
            await App.Database.DeleteJanr(Janr);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Janr newJanr = new Janr { Name = entryName.Text };
            await App.Database.AddJanr(newJanr);
            await Shell.Current.GoToAsync("..");
        }
    }
}