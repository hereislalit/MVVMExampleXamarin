using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMExample.viewmodels;

namespace MVVMExample
{
	public partial class MainPage : ContentPage
	{
        PopUpClass popUp;
        public MainPage()
        {
            InitializeComponent();
            popUp = new PopUpClass(this);
        }
/*
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = new Button
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = "Hello this is Main",
            };
            button.Clicked += hideButtonClick;
            popUp.setCustomView(button);
            popUp.showPopup();
        }

        private void hideButtonClick(object sender, EventArgs e)
        {
            popUp.hidePopUp();
        }
    */


        /*
        private void Button_Clicked(object sender, EventArgs e)
        {
                personListViewModel.addPersonCommand(PersonEntry.Text, PersonLastEntry.Text);
        }
        */
    }
}
