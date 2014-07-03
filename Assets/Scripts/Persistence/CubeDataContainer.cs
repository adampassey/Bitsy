using UnityEngine;
using System.Collections.Generic;

using AdamPassey.Persistence.Serializable;

namespace AdamPassey.Persistence.Container
{
	[System.Serializable]
	public class CubeDataContainer : DataContainer
	{
		private List<SerializableMonoBehavior> data;
		
		public CubeDataContainer()
		{
			data = new List<SerializableMonoBehavior>();
		}
		
		public void Add(SerializableMonoBehavior go) {
			data.Add(go);
		}

		public List<SerializableMonoBehavior> GetData() {
			return data;
		}
	}
}
