using UnityEngine;
using System.Collections;

namespace Bitsy.Parallax {

	[AddComponentMenu("Environment/Parallax")]
	public class Parallax : MonoBehaviour {

		public GameObject materialObject;
		public float speed = 0.1f;

		protected Camera mainCamera;
		protected Vector3 offset;
		protected Vector3 previousPosition;

		// Use this for initialization
		public virtual void Start() {
	
			mainCamera = Camera.main;
			if (mainCamera == null) {
				Debug.LogError("Parallax requires a main camera to work.");
			}

			offset = mainCamera.transform.position - transform.position;
		}
	
		// Update is called once per frame
		public virtual void Update() {
			Vector3 currentPosition = mainCamera.transform.position;

			//	create the texture offset based on desired speed
			Vector2 textureOffset = materialObject.GetComponent<Renderer>().material.mainTextureOffset;
			textureOffset.x += (currentPosition.x - previousPosition.x) * speed;
			materialObject.GetComponent<Renderer>().material.mainTextureOffset = textureOffset;

			//	set the y position based on speed
			Vector3 newPosition = currentPosition;
			newPosition.y -= previousPosition.y * speed;

			//	update the parallax position
			transform.position = newPosition - offset;
			previousPosition = mainCamera.transform.position;
		}
	}
}
