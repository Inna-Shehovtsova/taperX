using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin;
using taperX.Models;


namespace taperX
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            //Repos r = DependencyService.Get<Repos>();
            //List<ToDoEvent> l = r.GetAll();
            //this.FindByName<Label>("show").Text = l[0].title;
            List<ToDoEvent> l = DependencyService.Get<IRepos>().GetAll();
           
            this.FindByName<Button>("show").Clicked += bcl;

        }
        private void bcl(object sender, System.EventArgs e)
        {
            // Repos r = DependencyService.Get<Repos>();
            this.Navigation.PushAsync(new Views.EventsTabbedPage());
        }
	}
}
