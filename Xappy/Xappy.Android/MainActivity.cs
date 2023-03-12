using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AndroidX.Core.View;
using Android.Content.Res;
using Xappy.Styles;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Platform.Android;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using Java.Interop;
using Xappy.Interface;

[assembly: Android.App.MetaData("com.google.android.maps.v2.API_KEY", Value = Xappy.ApiConstants.GoogleMapsKey),]
[assembly: Dependency(typeof(Xappy.Droid.StatusBarServices))]

namespace Xappy.Droid
{
    [Activity(
        Label = "Xappy", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme.Launcher",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            DualScreenService.Init(this);


            //Window.SetStatusBarColor(Android.Graphics.Color.White);
            //var s = SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable;
            //FindViewById(Android.Resource.Id.Content).SystemUiVisibility = (StatusBarVisibility)s;


            base.OnCreate(savedInstanceState);
            Instance = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                var s = SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable;
                FindViewById(Android.Resource.Id.Content).SystemUiVisibility = (StatusBarVisibility)s;
            }

           // SetStatusBarColor(System.Drawing.Color.Transparent, false); //black background and white text


            Xamarin.FormsMaps.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

         
            Window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);


            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                await Task.Delay(50);
                WindowCompat.GetInsetsController(Window, Window.DecorView).AppearanceLightStatusBars = darkStatusBarTint;
            }

            // Window.SetStatusBarColor(color.ToPlatformColor());
        }
    }

    public class StatusBarServices : MainActivity,IStatusBarServices
    {
        public async void UpdateStatusBarColour(bool darkStatusBarTint)
        {
            var activity = Xamarin.Essentials.Platform.CurrentActivity;
            var window = activity.Window;

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                await Task.Delay(50);
                //if (darkStatusBarTint)
                {
                    WindowCompat.GetInsetsController(window, window.DecorView).AppearanceLightStatusBars = darkStatusBarTint;
                }
            }
        }
    }
}