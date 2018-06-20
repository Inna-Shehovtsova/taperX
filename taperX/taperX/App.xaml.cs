using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace taperX
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            
            // Здесь нужен NavigationPage чтобы отображалось название родительской страницы
            MainPage = new NavigationPage( new Views.EventsTabbedPage());

           
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
