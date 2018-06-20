using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using Xamarin.Forms;

namespace taperX.Models
{
    public interface IRepos
    {
        ToDoEvent GetItem(string id);
        void write(ToDoEvent d);
        List<ToDoEvent> GetAll();
        void addNew();
    }
   
    //public class Repos:sqlReadWrite
    //{
    //    public Repos(string filename)
    //    { }
    //        SQLiteConnection database;
    //        public FriendRepository(string filename)
    //        {
    //            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
    //            database = new SQLiteConnection(databasePath);
    //            database.CreateTable<Friend>();
    //        }
    //        public IEnumerable<Friend> GetItems()
    //        {
    //            return (from i in database.Table<Friend>() select i).ToList();

    //        }
    //        public Friend GetItem(int id)
    //        {
    //            return database.Get<Friend>(id);
    //        }
    //        public int DeleteItem(int id)
    //        {
    //            return database.Delete<Friend>(id);
    //        }
    //        public int SaveItem(Friend item)
    //        {
    //        throw un
    //        //if (item.Id != 0)
    //        //{
    //        //    database.Update(item);
    //        //    return item.Id;
    //        //}
    //        //else
    //        //{
    //        //    return database.Insert(item);
    //        //}
    //        return 0;
    //        }
    //    }

   // }    
}
