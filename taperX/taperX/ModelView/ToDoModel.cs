using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using taperX.Models;

namespace taperX.ModelView
{
    public class ToDoModel : INotifyPropertyChanged, IEqualityComparer<ToDoModel>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ToDoEvent Model { get; private set; }
        public ToDoModel()
        {
            Model = new ToDoEvent();

        }

        public bool Equals(ToDoModel x, ToDoModel y)
        {
            if(x.ID == y.ID)
                return true;
            return false;
        }
        public string ID {
            get { return Model.id;  }
        set {
                if (Model.id != value)
                {
                    Model.id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string Title
        {
            get { return Model.title; }
            set
            {
                if (Model.title != value)
                {
                    Model.title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Description
        {
            get { return Model.description; }
            set
            {
                if (Model.description != value)
                {
                    Model.description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Start
        {
            get { return Model.startIs; }
            set
            {
                if (Model.startIs != value)
                {
                    Model.startIs = value;
                    OnPropertyChanged("Start");
                }
            }
        }
        public string End
        {
            get { return Model.endIs; }
            set
            {
                if (Model.endIs != value)
                {
                    Model.endIs = value;
                    OnPropertyChanged("End");
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        
        public int GetHashCode(ToDoModel obj)
        {
            return this.GetHashCode(obj);
        }
    }
}
