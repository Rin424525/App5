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
    public partial class LoginForm : ContentPage
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Entry_Clicked(object sender, EventArgs e)
        {
            string login = "admin";
            string password = "123456";

            if (login == Login.Text && password == Password.Text)
            {
                Shell.Current.GoToAsync("//JanrPage");
            }
            else
            {
                DisplayAlert("Уведомление", "Неправильный логин или пароль", "Ок");
            }
        }
    }
}