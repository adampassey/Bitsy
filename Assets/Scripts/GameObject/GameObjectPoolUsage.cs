using UnityEngine;
using System.Collections;

using Bitsy.GameObjectPool;

public class GameObjectPoolUsage : MonoBehaviour {

	public GameObject poolPrefab;
	public int poolCount = 10;

	private GameObjectPool<RollingBall> gameObjectPool;

	// Use this for initialization
	void Start() {
		gameObjectPool = new GameObjectPool<RollingBall>(poolPrefab, poolCount);
	}
	
	// Update is called once per frame
	void Update() {

		//	Example of creating an object from the pool
		if (Input.GetKeyDown(KeyCode.G)) {
			RollingBall go = gameObjectPool.Get();
			if (go != null) {
				Debug.Log("Spawned an object from the pool.");

				//	Do not destroy your object with GameObject.Destroy,
				//	instead deactivate it with go.SetActive(false)
				//	this will keep it in the pool
			}
		}
	}
}
