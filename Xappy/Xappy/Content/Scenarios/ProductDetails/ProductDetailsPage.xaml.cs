using System.Diagnostics;
using Xamarin.Forms;
using System;
using Xappy.Interface;

namespace Xappy.Content.Scenarios.ProductDetails
{
    public partial class ProductDetailsPage : ContentPage
    {
        private IStatusBarServices service;
        public ProductDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            service = DependencyService.Get<IStatusBarServices>();
            (BindingContext as ProductDetailsViewModel).SkeletonCommand.Execute(null);
        }

        void FakeNavBar_PropertyChanging(System.Object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            // Debug.WriteLine(Convert.ToDouble(FakeNavBar.Opacity));
            if (service != null)
            {
                var opacity = Convert.ToDouble(FakeNavBar.Opacity);
                if (opacity < 0.9)
                {
                    //white
                    service.UpdateStatusBarColour(false);
                }
                else if (opacity > 0.95)
                {
                    //black
                    service.UpdateStatusBarColour(true);
                }
            }
        }
    }
}