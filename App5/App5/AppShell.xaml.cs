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
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SerialDetails), typeof(SerialDetails));
            Routing.RegisterRoute(nameof(SerialPage), typeof(SerialPage));
            Routing.RegisterRoute(nameof(JanrPage), typeof(JanrPage));

        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//LoginForm");
        }
    }
} 