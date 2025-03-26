using System;
using System.Security;

namespace Pharmacy.Frontend.Service;

public interface ILocationService
{
    Task<LocationResponse> GetCurrentLocation();

}
public class LocationService : ILocationService
{
    public async Task<LocationResponse> GetCurrentLocation()
    {
        var status = await Permissions.RequestAsync<Permissions.LocationWhenIUse>();
        if (status != PermissionStatus.Granted)
        {
            throw new CustomerAccessDeniedException("Access Denied");
        }
        var location = await Geolocation.GetLocationAsync(new GeolocationRequest
        {
            DesiredAccuracy = GeolocationAccuracy.Best,
            Timeout = TimeSpan.FromSeconds(30),
            RequestFullAccuracy = true
        });
        if(location == null)
        {
            return new LocationResponse(location.Latitude, location.Longitude);
        }
        else
            return null!;

        
    }
    public class CustomerAccessDeniedException(string message) :Exception(message);
}

public record LocationResponse(double Lat, double Lng);
