using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mapbox.Utils;
using Mapbox.Examples;
using Unity.VisualScripting;
using GeoCoordinatePortable;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector]
    public Auxiliar.Polo polo;


    LocationStatus playerLocation;
    Vector2d eventPosition;
    [SerializeField] double maxDistance = 78;
    GeoCoordinate currentPlayerLocation, eventLoc;
    double distance;
    UI_MenuManager menuManager;

    private void Start()
    {
        menuManager = GameObject.Find("UIGameController").GetComponent<UI_MenuManager>();
    }
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
    private void OnMouseDown()
    {
        Logic();
    }



    void Logic()
    {
        if (distance <= maxDistance)
        {
            MiniGameController.instance.miniGamePolo = polo;
            menuManager.DisplayStartEventPanel();
            menuManager.CloseGamePlayPanel();
        }
        else
        {
            menuManager.DisplayGamePlayPanel();
            menuManager.CloseStartEventPanel();
        }

    }

    public void setEventPosition(Vector2d p)
    {
        playerLocation = GameObject.Find("Canvas").GetComponent<LocationStatus>();
        eventPosition = p;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Logic();
    }

}
