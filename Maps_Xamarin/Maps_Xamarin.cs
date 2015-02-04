using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Maps_Xamarin
{
    public class App : Application
    {
        public App()
        {
            var locationService = DependencyService.Get<ILocationService>();

            var map = new Map()
            {
                MapType = MapType.Satellite,
                    VerticalOptions = LayoutOptions.FillAndExpand
            };                

            var button = new Button()
            {
                Text = "Go",
            };
            button.Clicked += async (object sender, EventArgs e) => 
            {
                    Geocoder coder = new Geocoder();
                    var positionResult = await coder.GetPositionsForAddressAsync("151 N 8th st, lincoln, ne");
                    Position[] positions = positionResult.ToArray();
                    var p = positions.FirstOrDefault();
                    var mapSpan = MapSpan.FromCenterAndRadius
                        (p, // lat / lon
                         Distance.FromMiles(0.0)); // distance from earth 
                    map.MoveToRegion(mapSpan);
            };

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        map,
                        button
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

