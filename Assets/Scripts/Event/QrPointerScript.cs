using GeoCoordinatePortable;
using Mapbox.Examples;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QrPointerScript : MonoBehaviour
{
    

    LocationStatus playerLocation;
    Vector2d eventPosition;
    [SerializeField] double maxDistance = 78;
    GeoCoordinate currentPlayerLocation, eventLoc;
    double distance;

    
    private void Update()
    {
        currentPlayerLocation = new GeoCoordinatePortable.GeoCoordinate(playerLocation.getLatitude(), playerLocation.getLongitude());
        eventLoc = new GeoCoordinatePortable.GeoCoordinate(eventPosition[0], eventPosition[1]);
        distance = currentPlayerLocation.GetDistanceTo(eventLoc);

        if (distance > maxDistance)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {


            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    
    public void setEventPosition(Vector2d p)
    {
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        eventPosition = p;
    }

   
}
