using RegistrationForm.ViewModels;
using Xamarin.Forms;

namespace RegistrationForm.Pages
{
	public partial class RegistrationPage : ContentPage
	{
        RegistrationPageViewModel _vm;

        public RegistrationPage()
		{
			InitializeComponent();

            this.BindingContext = _vm = new RegistrationPageViewModel();
			// why not change the form based on country selection
        }

        //void Handle_SelectedIndexChanged (object sender, System.EventArgs e)
        //{
        //    _vm.SelectedCountry = (sender as Picker).Items[(sender as Picker).SelectedIndex];
        //}
	}
}
