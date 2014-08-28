using UnityEngine;
using System.Collections.Generic;

using Bitsy.Persistence;
using Bitsy.Persistence.Container;
using Bitsy.Persistence.Serializable;

public class PersistenceUsage : MonoBehaviour {

	public GameObject serializableCubePrefab;

	private GameObjectDataContainer dataContainer;
	private string filepath = "game-objects";
	private List<GameObject> gameObjects;

	// Use this for initialization
	public void Start() {
		dataContainer = new GameObjectDataContainer();
		gameObjects = new List<GameObject>();

		GameObjectDataContainer loadedDataContainer = Persister.Load<GameObjectDataContainer>(filepath, new GameObjectDataContainer());
		if (loadedDataContainer != null) {
			foreach (SerializableGameObject c in loadedDataContainer.GetData()) {
				GameObject go = (GameObject)GameObject.Instantiate(serializableCubePrefab, c.position.ToVector3(), Quaternion.identity);
				go.transform.parent = transform;
				gameObjects.Add(go);
			}
		}
	}
	
	// Update is called once per frame
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Q)) {
			GameObject go = (GameObject)GameObject.Instantiate(serializableCubePrefab, Vector3.zero, Quaternion.identity);
			go.transform.parent = transform;
			gameObjects.Add(go);
		}
	}

	//	On Destroy script, save
	public void OnDestroy() {
		foreach (GameObject go in gameObjects) {
			SerializableGameObject s = new SerializableGameObject(go);
			dataContainer.Add(s);
		}
		Persister.Save<GameObjectDataContainer>(filepath, dataContainer);
	}
}
