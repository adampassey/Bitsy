using UnityEngine;
using System.Collections;

using Bitsy.Util;

namespace Bitsy.GameObjectPool {

	public class GameObjectPool<T> where T : MonoBehaviour {

		private T[] gameObjects;
		private GameObject prefab;
		private int count;
		private GameObject parent;
		private CoroutineDispatcher coroutineDispatcher = CoroutineDispatcher.GetInstance();

		private static string parentName = "Game Object Pool: ";

		/**
		 *	Create an instance of the GameObjectPool with
		 *	the prefab and the count of allowable prefabs
		 *	@param prefab The prefab to spawn
		 *	@param count The total number of spawned prefabs
		 **/
		public GameObjectPool(GameObject prefab, int count) {
			gameObjects = new T[count];
			this.prefab = prefab;
			this.count = count;

			parent = new GameObject();
			parent.name = parentName + prefab.name;

			coroutineDispatcher.DispatchCoroutine(CreatePool());
		}

		/**
		 *	Use CreatePool courotine to populate the
		 * 	object pool over time.
		 * 
		 **/
		public IEnumerator CreatePool() {
			for (int i = 0; i < count; i++) {
				//	TODO: use a buffer as to not instantiate all, 
				//	but only what is needed
				GameObject go = (GameObject)GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
				go.transform.parent = parent.transform;
				go.SetActive(false);

				T co = go.GetComponent<T>();
				gameObjects[i] = co;

				yield return null;
			}
		}

		/**
		 * 	Get an item from the pool
		 * 	May return null if no objects are available
		 * 	@returns T The type of object placed in the pool
		 **/
		public T Get() {

			//	TODO: this could be more efficient. consider having
			//	two lists of types, one for active and the other for
			//	inactive. push / pop between them.
			foreach (T go in gameObjects) {
				if (go.gameObject.activeSelf == false) {
					go.gameObject.SetActive(true);
					return go;
				}
			}
			return null;
		}
	}
}
