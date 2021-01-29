using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationScript : MonoBehaviour
{
    public Text PrintLocation;
    IEnumerator Start()
    {
        
        // First, check if user has location service enabled
        Debug.Log("Looking for location");
        PrintLocation.text = "Looking for location";
        if (!Input.location.isEnabledByUser)
        {
            PrintLocation.text = "Location is not enabled by user";
            yield break;
        }
            

        // Start service before querying location
        Input.location.Start();
        PrintLocation.text = "Starting location query...";

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            PrintLocation.text = "Initializing . . .";
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            PrintLocation.text = "Timed out";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            PrintLocation.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            PrintLocation.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        }

        

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
}