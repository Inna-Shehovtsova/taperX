using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace taperX.ModelView
{
    public class ToDoEventListModelView : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoModel> ToDoListView
        { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackCommand { protected set; get; }
        public ICommand Refresh { protected set; get; }
        public ICommand AddNewCommand { protected set; get; }

        public bool NeedToEdit = false;
        public bool Active = false;

        ToDoModel selectedEvent;

        public ToDoEventListModelView()
        {
            AddNewCommand = new Command(addEvent);
            Refresh = new Command(GetData);
            GetData();
        }

        public ToDoEventListModelView(bool active, bool redact)
        {
            AddNewCommand = new Command(addEvent); Refresh = new Command(GetData);
            this.Active = active;
            this.NeedToEdit = redact;
            GetData();
        }

        public async void GetData()
        {
            var tempListView = new ObservableCollection<ToDoModel>();
            await Task.Delay(1000); // use delay for waiting for download data
            List<Models.ToDoEvent> l = DependencyService.Get<Models.IRepos>().GetAll();
            foreach (Models.ToDoEvent item in l)
            {
                ToDoModel m = new ToDoModel() { ID = item.id, Title = item.title, Description = item.description, Start = item.startIs, End = item.endIs };
                tempListView.Add(m);
            }
            Func<ToDoModel, bool> selectionPredicate;
            IOrderedEnumerable<ToDoModel> selected;

            if (Active)
                selectionPredicate = s => DateTime.Parse(s.Start) > DateTime.Now;
            else
                selectionPredicate = s => DateTime.Parse(s.Start) < DateTime.Now;

            if (Active)
                selected = tempListView.Where(selectionPredicate).OrderBy(m => DateTime.Parse(m.Start));
            else
                selected = tempListView.Where(selectionPredicate).OrderByDescending(m => DateTime.Parse(m.Start));

            if (selected.Count() > 0)
            {
                ToDoListView = new ObservableCollection<ToDoModel>();
                foreach (var item in selected)
                {
                    ToDoModel m = new ToDoModel() { ID = item.ID, Title = item.Title, Description = item.Description, Start = item.Start, End = item.End };
                    ToDoListView.Add(m);
                }
//                if (!Active)
//                {
//                    ToDoModel m = new ToDoModel() { ID = "0", Title = "Не забыть сказать жене ", Description = "Инна, я тебя люблю", Start = DateTime.Now.ToString(), End = DateTime.Now.ToString() };
//                    ToDoListView.Insert(0, m);
//                }
                OnPropertyChanged("ToDoListView");
            }
        }
        
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        
        public ToDoModel SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                if (selectedEvent != value)
                {
                    ToDoModel tempComp = value;
                    selectedEvent = tempComp;
                    OnPropertyChanged("SelectedEvent");
                    if (this.NeedToEdit)
                    {
                        DependencyService.Get<Models.IRepos>().write(tempComp.Model);
                    }                   
                }
            }
        }

        private void addEvent()
        {
            DependencyService.Get<Models.IRepos>().addNew();
        }
    }
}

