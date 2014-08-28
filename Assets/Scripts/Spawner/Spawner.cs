using UnityEngine;
using System.Collections;

namespace Bitsy.Spawner {

	public class Spawner : MonoBehaviour {

		public GameObject prefabToSpawn;

		// Use this for initialization
		void Start() {
			GameObject spawnedObject = (GameObject)GameObject.Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
			spawnedObject.transform.parent = transform.parent;

			CameraController cameraController = (CameraController)Camera.main.gameObject.GetComponent<CameraController>();
			cameraController.target = spawnedObject;
		}

		public void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, 1f);
		}

		public void Update() {
			Destroy(gameObject);
		}
	}

}