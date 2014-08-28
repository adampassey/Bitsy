using UnityEngine;
using System.Collections;

namespace AdamPassey.Persistence.Serializable {

	/**
	 * 	Serializable version of a Vector3
	 **/
	[System.Serializable]
	public class SerializableVector3 {

		public float x;
		public float y;
		public float z;

		public SerializableVector3(Vector3 v) {
			x = v.x;
			y = v.y;
			z = v.z;
		}

		/**
		 *	Return a Vector3 from this SerializableVector3
		 **/
		public Vector3 ToVector3() {
			return new Vector3(x, y, z);
		}
	}
}
