using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RegistrationForm.Pages
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);

			var g = new TapGestureRecognizer();
			g.Tapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new RegistrationPage());
			};
			RegisterBtn.GestureRecognizers.Add(g);

		}
	}
}
