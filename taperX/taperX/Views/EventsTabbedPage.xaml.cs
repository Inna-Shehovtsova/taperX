using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taperX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsTabbedPage : TabbedPage
    {
        
        public EventsTabbedPage ()
        {
            InitializeComponent();
            this.Children[0].Title = "Активные";
            this.Children[1].Title = "Завершенные";
            ModelView.ToDoEventListModelView mv = new ModelView.ToDoEventListModelView(true, true) ;
            this.Children[0].BindingContext = mv;
            this.Children[1].BindingContext = new ModelView.ToDoEventListModelView() ;
            

        }
    }
}