﻿using Xamarin.Forms;

using Xappy.Content.Scenarios.ProductDetails;



namespace Xappy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
       
           // Routing.RegisterRoute("map", typeof(MapPage));
            //Routing.RegisterRoute("login", typeof(LoginPage));
            //Routing.RegisterRoute("otherlogin", typeof(Content.Scenarios.OtherLogin.LoginPage));
           // Routing.RegisterRoute("todo", typeof(ItemsPage));
            //Routing.RegisterRoute("conversation", typeof(ConversationPage));
            Routing.RegisterRoute("productdetails", typeof(ProductDetailsPage));

            // ToDo
           // Routing.RegisterRoute("add", typeof(NewItemPage));

            //Routing.RegisterRoute("photo", typeof(PhotoDetailsPage));

            //Routing.RegisterRoute("onboarding", typeof(Content.Scenarios.Onboarding.IndexPage));
            //Routing.RegisterRoute("photogallery", typeof(Content.Scenarios.PhotoGallery.IndexPage));
        }
    }
}
