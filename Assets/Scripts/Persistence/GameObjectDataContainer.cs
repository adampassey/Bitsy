using UnityEngine;
using System.Collections.Generic;

using AdamPassey.Persistence.Serializable;

namespace AdamPassey.Persistence.Container
{
	[System.Serializable]
	public class GameObjectDataContainer : DataContainer
	{
		private List<SerializableGameObject> data;
		
		public GameObjectDataContainer()
		{
			data = new List<SerializableGameObject>();
		}
		
		public void Add(SerializableGameObject go) {
			data.Add(go);
		}

		public void AddAll(List<SerializableGameObject> list) {
			data = list;
		}

		public List<SerializableGameObject> GetData() {
			return data;
		}
	}
}
