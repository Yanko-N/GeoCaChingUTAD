﻿namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Utils;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class LocationStatus : MonoBehaviour
	{

		[SerializeField]
		Text _statusText;

		private AbstractLocationProvider _locationProvider = null;
		Location currLoc;
		void Start()
		{
			if (null == _locationProvider)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
			}
		}


		void Update()
		{
			
			currLoc = _locationProvider.CurrentLocation;

			if (currLoc.IsLocationServiceInitializing)
			{
				_statusText.text = "location services are initializing";
			}
			else
			{
				if (!currLoc.IsLocationServiceEnabled)
				{
					_statusText.text = "location services not enabled";
				}
				else
				{
					if (currLoc.LatitudeLongitude.Equals(Vector2d.zero))
					{
						_statusText.text = "Waiting for location ....";
					}
					else
					{
						_statusText.text = " ";
					}
				}
			}

		}

		public void OpenSideMenuClick()
		{
			UI_MenuManager.instance.OpenSideMenuButtonClick();
		}
        public void RecenterCamaraButtonClick()
        {
			

            var _mapManager = GameObject.Find("LocationBasedGame").GetComponentInChildren<QuadTreeCameraMovement>()._mapManager;
            _mapManager.UpdateMap(currLoc.LatitudeLongitude);
            

        }
        public double getLongitude()
		{
			return currLoc.LatitudeLongitude.y;
		}

		public double getLatitude()
		{
			return currLoc.LatitudeLongitude.x;
		}
	}
}
