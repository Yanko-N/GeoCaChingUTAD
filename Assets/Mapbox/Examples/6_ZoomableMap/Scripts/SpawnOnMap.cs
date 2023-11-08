namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		Auxiliar.Polo[] _polosLocation;

		[SerializeField]
		[Geocode]
		string[] _locationStrings;
		Vector2d[] _locations;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject _markerPrefab;

		List<GameObject> _spawnedObjects;

		void Start()
		{
			_locations = new Vector2d[_locationStrings.Length];
			_spawnedObjects = new List<GameObject>();

			for (int i = 0; i < _locationStrings.Length; i++)
			{
				var locationString = _locationStrings[i];
				_locations[i] = Conversions.StringToLatLon(locationString);
				var instance = Instantiate(_markerPrefab);
				instance.GetComponent<TouchManager>().setEventPosition(_locations[i]);

				switch (_polosLocation[i])
				{
					case Auxiliar.Polo.ECT://ciencas e tecnologia
						instance.GetComponent<TouchManager>().polo = Auxiliar.Polo.ECT;
						break;
                    case Auxiliar.Polo.ESS: // saude
                        instance.GetComponent<TouchManager>().polo = Auxiliar.Polo.ESS;

                        break;
                    case Auxiliar.Polo.ECAV: //agrarias e veterinarias
                        instance.GetComponent<TouchManager>().polo = Auxiliar.Polo.ECAV;

                        break;
                    case Auxiliar.Polo.ECHS: //humanas sociais
                        instance.GetComponent<TouchManager>().polo = Auxiliar.Polo.ECHS;

                        break;
                    case Auxiliar.Polo.ECVA: // vida e ambiente
                        instance.GetComponent<TouchManager>().polo = Auxiliar.Polo.ECVA;

                        break;

                }

				instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
				instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				_spawnedObjects.Add(instance);
			}
		}

		private void Update()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];
				spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
				spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
			}
		}
	}
}