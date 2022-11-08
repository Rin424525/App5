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
        private int janrId;
        Janr janr = new Janr();
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
            await App.Database.GetSerial(JanrId);
        }
        private async void Button_Save(object sender, EventArgs e)
        {
            janr.Name = entryName.Text;
            await App.Database.EditJanr(janr);
            await Navigation.PopAsync();
        }

        private async void Button_Dell(object sender, EventArgs e)
        {
            janr.Name = entryName.Text;
            await App.Database.DeleteJanr(janr);
            await Navigation.PopAsync();
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Janr newJanr = new Janr { Name = entryName.Text };
            await App.Database.AddJanr(newJanr);
            await Navigation.PopAsync();
        }
    }
}