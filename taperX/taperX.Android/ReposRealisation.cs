using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Xamarin.Forms;
using taperX.Models;

[assembly: Dependency(typeof(taperX.Droid.Repos_Android))]
namespace taperX.Droid
{
    class Repos_Android : Models.IRepos
    {
        string[] projection =
        {        Android.Provider.CalendarContract.EventsColumns.Title,
                Android.Provider.CalendarContract.EventsColumns.Description,
                Android.Provider.CalendarContract.Events.InterfaceConsts.Id,
                Android.Provider.CalendarContract.Events.InterfaceConsts.Dtstart,
                Android.Provider.CalendarContract.Events.InterfaceConsts.Dtend
        };

        public static Android.Content.ContentResolver cr;
        public static Activity act;

        public Repos_Android()
        {        }

        public List<ToDoEvent> GetAll()
        {
            List<ToDoEvent> l = new List<ToDoEvent>();
            if (cr != null)
            {
                Android.Database.ICursor cur = cr.Query(Android.Provider.CalendarContract.Events.ContentUri, projection, null, null, null);
                string[] result = new string[cur.Count + 1];

                int[] colindexes = new int[projection.Length];
                for (int i = 0; i < projection.Length; i++)
                {
                    colindexes[i] = cur.GetColumnIndexOrThrow(projection[i]);
                }
                
                while (cur.MoveToNext())
                {
                    ToDoEvent b = new ToDoEvent();
                    b.title = cur.GetString(colindexes[0]);
                    b.description = cur.GetString(colindexes[1]);
                    b.id = cur.GetString(colindexes[2]);

                    long msS = cur.GetLong(colindexes[3]);

                    DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(msS).ToLocalTime();
                    b.startIs = date.ToString();
                    msS = cur.GetLong(colindexes[4]);

                    date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(msS).ToLocalTime();
                    b.endIs = date.ToString();

                    l.Add(b);
                }
                cur.Close();
            }
            return l;
        }

        public ToDoEvent GetItem(string id)
        {
            throw new NotImplementedException();
        }

        public void write(ToDoEvent d)
        {
            Android.Net.Uri uri = ContentUris.WithAppendedId(Android.Provider.CalendarContract.Events.ContentUri, long.Parse(d.id));
            Intent intent = new Intent(Intent.ActionEdit).SetData(uri).PutExtra(projection[0], d.title).PutExtra(projection[1], d.description);
            act.StartActivity(intent);
        }

        public void addNew()
        {
            Intent intent = new Intent(Intent.ActionEdit).SetData(Android.Provider.CalendarContract.Events.ContentUri);
            act.StartActivity(intent);
        }
    }
}





