using UnityEngine;
using System.Collections;

namespace AdamPassey.Persistence.Serializable {

	/**
	 * 	Serializable Game Object. Currently only contains
	 * 	an objects position.
	 **/
	[System.Serializable]
	public class SerializableGameObject {

		public SerializableVector3 position;

		public SerializableGameObject(GameObject obj) {
			position = new SerializableVector3(obj.transform.position);
		}
	}
}
