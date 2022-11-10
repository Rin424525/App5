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

    [QueryProperty(nameof(IdSerial), nameof(IdSerial))]
    public partial class SerialDetails : ContentPage
    {
        private int serialId;
        Serial serial = new Serial();
        public int IdSerial
        {
            get => serialId; 
            set
            {
                IdSerial = value;
                if (serialId != 0)
                {
                    SetSerial();
                }               
            }
        }
       
        public SerialDetails()
        {
            InitializeComponent();
        }
        private async void SetSerial()
        {
            await App.Database.GetSerial(IdSerial);
        }
        private async void Button_Save(object sender, EventArgs e)
        {
            serial.Name = entryName.Text;
            await App.Database.EditSerial(serial);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Dell(object sender, EventArgs e)
        {
            serial.Name = entryName.Text;
            await App.Database.DeleteSerial(serial);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Serial newSerial = new Serial{Name = entryName.Text };
            await App.Database.AddSerial(newSerial);
            await Shell.Current.GoToAsync("..");
        }
    }
}