using UnityEngine;
using System.Collections.Generic;

using AdamPassey.Persistence.Serializable;

namespace AdamPassey.Persistence.Container {

	/**
	 * 	A Data Container for Serializable Game Objects
	 **/
	[System.Serializable]
	public class GameObjectDataContainer : DataContainer {

		private List<SerializableGameObject> data;

		/**
		 *	Construct this Data Container
		 **/
		public GameObjectDataContainer() {
			data = new List<SerializableGameObject>();
		}

		/**
		 * 	Construct this Data Container with a list
		 * 
		 * 	@parm list The list of SerializableGameObject's
		 **/
		public GameObjectDataContainer(List<SerializableGameObject> list) {
			data = list;
		}

		/**
		 * 	Add a Serializable Game Object to this Data Container
		 * 
		 * 	@param serializableGameObject The object to add to the container
		 **/
		public void Add(SerializableGameObject serializableGameObject) {
			data.Add(serializableGameObject);
		}

		/**
		 * 	Add all Serializable Game Objects to this Data Container
		 * 
		 * 	@param List<SerializableGameObject> The object to adds to the container
		 **/
		public void AddAll(List<SerializableGameObject> list) {
			foreach (SerializableGameObject go in list) {
				data.Add(go);
			}
		}

		/**
		 * 	Get the Serializable Game Objects within this Data Container
		 * 
		 * 	@returns List<SerializableGameObject>
		 **/
		public List<SerializableGameObject> GetData() {
			return data;
		}
	}
}
