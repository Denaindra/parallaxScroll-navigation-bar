﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lottie.Forms.Platforms.Ios;

using Foundation;
using UIKit;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using Xappy.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(Xappy.iOS.StatusBarServices))]
namespace Xappy.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UINavigationBar.Appearance.Translucent = false; // no alpha fade nonsense

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            global::Xamarin.Forms.FormsMaterial.Init();
            Xamarin.FormsMaps.Init();

            return base.FinishedLaunching(app, options);
        }

        
    }

    public class StatusBarServices : IStatusBarServices
    {
        public void UpdateStatusBarColour(bool darkStatusBarTint)
        {
            
        }
    }
}
