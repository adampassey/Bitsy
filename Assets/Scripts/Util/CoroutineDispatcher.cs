using UnityEngine;
using System.Collections;

namespace Bitsy.Util {

	/**
	 * Used to start Coroutines outside of MonoBehaviour objects
	 * 
	 **/
	public class CoroutineDispatcher : Singleton<CoroutineDispatcher> {

		/**
		 * Start a Coroutine
		 * 
		 * @param IEnumerator routine
		 * 
		 **/
		public void DispatchCoroutine(IEnumerator routine) {
			StartCoroutine(routine);
		}
	}
}
