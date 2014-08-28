using UnityEngine;
using System.Collections;

namespace Bitsy.WorldMap {

	public class Controller : MonoBehaviour {

		public WorldMap worldmap;
	
		// Update is called once per frame
		void Update() {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				worldmap.SelectDirection(Direction.Left);
			}

			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				worldmap.SelectDirection(Direction.Right);
			}

			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				worldmap.SelectDirection(Direction.Up);
			}

			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				worldmap.SelectDirection(Direction.Down);
			}

			if (Input.GetKeyDown(KeyCode.Return)) {
				worldmap.LoadLevel();
			}
		}
	}
}