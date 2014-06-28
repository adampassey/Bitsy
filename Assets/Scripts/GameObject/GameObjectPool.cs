using UnityEngine;
using System.Collections;

namespace AdamPassey.Pool
{
	public class GameObjectPool<T> where T : MonoBehaviour
	{
		private T[] gameObjects;

		/**
		 *	Create an instance of the GameObjectPool with
		 *	the prefab and the count of allowable prefabs
		 *	@param prefab The prefab to spawn
		 *	@param count The total number of spawned prefabs
		 **/
		public GameObjectPool(GameObject prefab, int count)
		{
			gameObjects = new T[count];

			for (int i = 0; i < count; i++) {

				//	TODO: Instantiate these into a parent object for cleanliness
				//	also, instead of instantiating all at once, use a buffer
				GameObject go = (GameObject)GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
				go.SetActive(false);

				T co = go.GetComponent<T>();
				gameObjects[i] = co;
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
