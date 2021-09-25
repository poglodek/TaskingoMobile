using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskingoMobile.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : Xamarin.CommunityToolkit.UI.Views.Popup
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        public void SetContentText(string text)
        {
            TextOnPopup.Text = text;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}