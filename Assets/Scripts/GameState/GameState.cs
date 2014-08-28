using UnityEngine;
using System.Collections;

namespace Bitsy.GameState {

	public class GameState {

		public enum States {
			Paused,
			Running
		}
		;

		//	Running by default
		private static States state = States.Running;

		/**
		 * 	Get the current Game State
		 **/
		public static States State() {
			return state;
		}

		/**
		 * 	Set the current Game State
		 * 	@param gameState The Game State
		 **/
		public static void SetState(States gameState) {
			state = gameState;
		}

		/**
		 * 	Convenience method for checking if the
		 * 	Game State is running
		 **/
		public static bool IsRunning() {
			return state == States.Running;
		}

		/**
		 * 	Convenience method for checking if the
		 * 	Game State is paused
		 **/
		public static bool IsPaused() {
			return state == States.Paused;
		}
	}

}