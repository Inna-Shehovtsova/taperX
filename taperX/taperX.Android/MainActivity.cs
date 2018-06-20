using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Util;
namespace taperX.Droid
{
    [Activity(Label = "taperX", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        string[] projection =
       {        Android.Provider.CalendarContract.EventsColumns.Title,
                Android.Provider.CalendarContract.EventsColumns.Description,
                Android.Provider.CalendarContract.Events.InterfaceConsts.Id,
               Android.Provider.CalendarContract.Events.InterfaceConsts.Dtstart,
               Android.Provider.CalendarContract.Events.InterfaceConsts.Dtend
        };
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            Repos_Android.cr = this.ContentResolver;
            Repos_Android.act = this;

//            //  Android.Database.Sqlite.SQLiteDatabase db;
//            //Android.Provider.CalendarContract c = new ;
//            string b = Android.Provider.CalendarContract.EventsEntity.ContentUri.ToString();
//            Android.Content.ContentResolver c = this.ContentResolver;
//            string dd= Android.Provider.CalendarContract.ExtraEventBeginTime;
//            Android.Database.ICursor cur = c.Query(Android.Provider.CalendarContract.Events.ContentUri, projection, null, null, null);
//            string[] result = new string[cur.Count+1];
            
//            int[] colindexes = new int[projection.Length]; 
//            for ( int i = 0; i< projection.Length; i++)
//            {
//                colindexes[i] = cur.GetColumnIndexOrThrow(projection[i]);
//            }
           

//            while (cur.MoveToNext())
//            {
//                for(int i = 0; i< 2; i++)
//                {
//                    result[cur.Position] += cur.GetString(colindexes[i]) + "  \t ";
//                }
//                long msS = cur.GetLong(colindexes[3]);
               
//                DateTime date = new DateTime(1970, 1, 1, 0, 0, 0,
//DateTimeKind.Utc).AddMilliseconds(msS).ToLocalTime();
//                result[cur.Position] +=date.ToLongDateString() + " \\ ";
               
               
//            }
//            cur.Close();
          
        }
    }
}

