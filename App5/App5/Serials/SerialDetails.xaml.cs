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

    [QueryProperty(nameof(SerialId), nameof(SerialId))]
    public partial class SerialDetails : ContentPage
    {
        private int serialId;
        Serial serial = new Serial();
        public int SerialId
        {
            get => serialId; set
            {
                SerialId = value;
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
            await App.Database.GetSerial(SerialId);
        }
        private async void Button_Save(object sender, EventArgs e)
        {
            serial.Name = entryName.Text;
            await App.Database.EditSerial(serial);
            await Navigation.PopAsync();
        }

        private async void Button_Dell(object sender, EventArgs e)
        {
            serial.Name = entryName.Text;
            await App.Database.DeleteSerial(serial);
            await Navigation.PopAsync();
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Serial newSerial = new Serial{Name = entryName.Text };
            await App.Database.AddSerial(newSerial);
            await Navigation.PopAsync();
        }
    }
}