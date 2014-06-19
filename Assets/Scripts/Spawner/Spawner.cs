using UnityEngine;
using System.Collections;

namespace AdamPassey.Spawner
{
	public class Spawner : MonoBehaviour
	{

		public GameObject prefabToSpawn;

		// Use this for initialization
		void Start() {
			GameObject.Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
		}

		public void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, 1f);
		}

		public void Update() {
			Destroy(gameObject);
		}
	}

}