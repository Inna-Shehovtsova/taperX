using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace UITest1
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then 
            // add a reference to the android project from the project containing this file
            app = ConfigureApp
                    .Android
                    .ApkFile("com.companyname.taperX-Signed.apk").DeviceSerial("8a435490")
                    .StartApp();           
        }

        [Test]
        public void AppLaunches()
        {
            //app.Screenshot("First screen.");
            app.Repl();
            app.WaitForElement("NoResourceEntry-6");
            app.Tap(e => e.Id("NoResourceEntry-6"));
            app.Tap(e => e.Id("NoResourceEntry-7"));
            
        }
    }
}

