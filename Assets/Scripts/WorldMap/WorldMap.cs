using UnityEngine;
using System.Collections.Generic;

namespace AdamPassey.WorldMap {

	public class WorldMap : MonoBehaviour {

		public List<LevelNode> levelNodes = new List<LevelNode>();
		public LevelNode current;

		public void Awake() {
			if (!current) {
				current = levelNodes[0];
			}
		}

		/**
		 * 	Select the level in the desired direction
		 * 	of the current node.
		 * 
		 **/
		public void SelectDirection(Direction dir) {
			current.SelectDirection(dir);
		}

		/**
		 * 	Select this current level
		 * 
		 **/
		public void LoadLevel() {
			current.LoadLevel();
		}
	}
}