using System;
using Xamarin.Forms.Maps;

namespace Maps_Xamarin
{
    public interface ILocationService
    {
        MapSpan Search(string address);
    }
}

