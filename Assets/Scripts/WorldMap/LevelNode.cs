using UnityEngine;
using System.Collections.Generic;

namespace AdamPassey.WorldMap {

	public class LevelNode : MonoBehaviour {

		public List<Level> levels = new List<Level>();
		public List<Direction> directions = new List<Direction>();
		public Level highlightedLevel;

		/**
		 * 	Select the level at the desired direction
		 * 
		 **/
		public void SelectDirection(Direction dir) {
			DeselectAllLevels();

			int index = directions.IndexOf(dir);
			if (index != -1) {
				Level level = levels[index];
				level.selected = true;
				highlightedLevel = level;
			}
		}

		/**
		 * 	Load the currently highlighted level
		 * 
		 **/
		public void LoadLevel() {
			highlightedLevel.Load();
		}

		private void DeselectAllLevels() {
			highlightedLevel = null;
			foreach (Level l in levels) {
				l.selected = false;
			}
		}
	}
}