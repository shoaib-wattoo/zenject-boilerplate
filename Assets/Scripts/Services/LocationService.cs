using UnityEngine;
using System.Collections;
using UnityEngine.Android;
using Zenject;

public class LocationService : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 5f;
    public Location naskilaGaming = new Location(30.7137728f, -94.6746161f);
    public Location testLoc = new Location(31.3327871f, 74.2663846f);
    public GeoFenceWishListData geoFenceWishList;
    float distance;
    bool notificationFired = false;
    [Inject] SignalBus signalBus;

    private void Start()
    {
        StartCoroutine(StartService());
        signalBus.Subscribe<VolumeChangeSignal>(OnUpdateVolume);

    }

    void OnUpdateVolume(VolumeChangeSignal data)
    {
        print("LocationService : Signal Revceid :: " + data.volume);
    }

    IEnumerator StartService()
    {
        print("LocationService Start");

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        int maxPermissionWait = 40;
        while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation) && maxPermissionWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxPermissionWait--;
        }

        if (maxPermissionWait < 1)
        {
            print("Permission Wait Timed out");
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

            // Access granted and location value could be retrieved
        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            if(Input.location.status == LocationServiceStatus.Running)
            {
                print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
                distance = CalculateDistance(Input.location.lastData.latitude, naskilaGaming.latitude, Input.location.lastData.longitude, naskilaGaming.longitude);

                if(distance < 500 && !notificationFired)
                {
                    notificationFired = true;
                    print("Services.ContentService.FireGeoFenceNotification(null);");
                }
            }

        }
    }

    public float CalculateDistance(float lat_1, float lat_2, float long_1, float long_2)
    {
        int R = 6371;
        var lat_rad_1 = Mathf.Deg2Rad * lat_1;
        var lat_rad_2 = Mathf.Deg2Rad * lat_2;
        var d_lat_rad = Mathf.Deg2Rad * (lat_2 - lat_1);
        var d_long_rad = Mathf.Deg2Rad * (long_2 - long_1);
        var a = Mathf.Pow(Mathf.Sin(d_lat_rad / 2), 2) + (Mathf.Pow(Mathf.Sin(d_long_rad / 2), 2) * Mathf.Cos(lat_rad_1) * Mathf.Cos(lat_rad_2));
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        var total_dist = R * c * 1000; // convert to meters
        return total_dist;
    }
}