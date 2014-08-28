using UnityEngine;
using System.Collections.Generic;

namespace Bitsy.WorldMap {

	public class Level : MonoBehaviour {

		public string scene;
		public bool selected = false;

		public void Load() {
			//	TODO: loading screen
			Application.LoadLevel(scene);
		}
	}
}