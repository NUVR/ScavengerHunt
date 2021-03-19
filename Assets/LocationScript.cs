using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocationScript : MonoBehaviour
{
    public Text PrintLocation;
    public static double XPosition;
    public static double YPosition;
    static int levelReached;
    /*
    public static IEnumerator FindLocation()
    {
        
        // First, check if user has location service enabled
        Debug.Log("Looking for location");
        //PrintLocation.text = "Looking for location";
        if (!Input.location.isEnabledByUser)
        {
            //PrintLocation.text = "Location is not enabled by user";
            yield break;
        }
            

        // Start service before querying location
        Input.location.Start();
        //PrintLocation.text = "Starting location query...";

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            //PrintLocation.text = "Initializing . . .";
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            //PrintLocation.text = "Timed out";
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            //PrintLocation.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            // PrintLocation.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            XPosition = Input.location.lastData.latitude;
            YPosition = Input.location.lastData.longitude;
        }

        

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
    */

    IEnumerator Start()
    {
        Debug.Log("ienumeratorr");
        levelReached = 0;
        // First, check if user has location service enabled
        Debug.Log("Looking for location");
        // echolocation.text = "Looking for location";
        if (!Input.location.isEnabledByUser)
        {
            levelReached = 1;
            yield break;
        }


        // Start service before querying location
        Input.location.Start();
        //echolocation.text = "Starting location query...";
        levelReached = 2;
        yield return new WaitForSeconds(3);
        // Wait until service initializes
        int maxWait = 2;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            //echolocation.text = "Initializing . . .";
            levelReached = 3;
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            //echolocation.text = "Timed out";
            levelReached = 4;

            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            //echolocation.text = "Unable to determine device location";
            levelReached = 6;

            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
            //   echolocation.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            levelReached = 7;
            XPosition = Input.location.lastData.latitude;

            YPosition = Input.location.lastData.longitude;



            //echolocation.text = Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
        }



        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }

    private void Update()
    {
        PrintLocation.text = XPosition + ", " + YPosition;
    }
}