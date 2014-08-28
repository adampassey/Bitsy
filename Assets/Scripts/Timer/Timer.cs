using UnityEngine;
using System.Collections;

namespace AdamPassey.Timer {

	public class Timer {

		private float time;

		public Timer() {
			time = Time.timeSinceLevelLoad;
		}

		/**
		 * 	Determine whether the time has passed
		 * 	Will automatically reset the timer if true
		 * 
		 * 	@param seconds the time (in seconds)
		 * 	@returns bool
		 **/
		public bool TimeHasPassed(float seconds) {
			float currentTime = Time.timeSinceLevelLoad;

			if (currentTime >= time + seconds) {
				time = currentTime;
				return true;
			}
			return false;
		}
	}
}