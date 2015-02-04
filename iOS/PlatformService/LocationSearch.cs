using System;
using System.Linq;
using Xamarin.Forms.Maps;
using Maps_Xamarin.iOS;
using MapKit;

[assembly: Xamarin.Forms.Dependency (typeof (LocationSearch))]

namespace Maps_Xamarin.iOS
{
    public class LocationSearch : ILocationService
    {
        public LocationSearch()
        {
        }

        public MapSpan Search(string address)
        {   
            Geocoder coder = new Geocoder();
            var task = coder.GetPositionsForAddressAsync(address);

            task.Wait();
            Position[] positions = task.Result.ToArray();
            var p = positions.FirstOrDefault();
            var result = MapSpan.FromCenterAndRadius(p, Distance.FromMiles(0.3));
            return result;
        }
    }
}

