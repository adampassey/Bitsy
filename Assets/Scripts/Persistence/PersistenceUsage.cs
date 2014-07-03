using UnityEngine;
using System.Collections;

using AdamPassey.Persistence;
using AdamPassey.Persistence.Container;
using AdamPassey.Persistence.Serializable;

public class PersistenceUsage : MonoBehaviour
{

	public GameObject serializableCubePrefab;

	private CubeDataContainer cubeDataContainer;
	private string filepath = "cube-data-03";

	// Use this for initialization
	public void Start() {
		cubeDataContainer = new CubeDataContainer();

		CubeDataContainer loadedDataContainer = Persister.Load<CubeDataContainer>(filepath, new CubeDataContainer());
		if (loadedDataContainer != null) {
			foreach (SerializableMonoBehavior c in loadedDataContainer.GetData()) {
				GameObject go = (GameObject)GameObject.Instantiate(serializableCubePrefab, c.position.ToVector3(), Quaternion.identity);
				AddGameObjectToDataContainer(go);
			}
		}
	}
	
	// Update is called once per frame
	public void Update() {
		if (Input.GetKeyDown(KeyCode.Q)) {
			GameObject go = (GameObject)GameObject.Instantiate(serializableCubePrefab, Vector3.zero, Quaternion.identity);
			AddGameObjectToDataContainer(go);

			Persister.Save<CubeDataContainer>(filepath, cubeDataContainer);
		}
	}

	private void AddGameObjectToDataContainer(GameObject o) {
		SerializableMonoBehavior monobehavior = new SerializableMonoBehavior();
		monobehavior.position = new SerializableVector3(o.transform.position);
		cubeDataContainer.Add(monobehavior);
	}

}
