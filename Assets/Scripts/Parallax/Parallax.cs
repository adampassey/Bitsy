using UnityEngine;
using System.Collections;

namespace AdamPassey.Parallax
{
	public class Parallax : MonoBehaviour
	{
		public GameObject quadObject;
		public float speed = 0.1f;

		private Camera mainCamera;
		private Vector3 previousPosition;
		private Vector3 offset;

		// Use this for initialization
		void Start() {
	
			mainCamera = Camera.main;
			if (mainCamera == null) {
				Debug.LogError("Circular Parallax requires a main camera to work.");
			}

			offset = mainCamera.transform.position - transform.position;
		}
	
		// Update is called once per frame
		void Update() {
			Vector3 currentPosition = mainCamera.transform.position;

			//	create the texture offset based on desired speed
			Vector2 textureOffset = quadObject.renderer.material.mainTextureOffset;
			textureOffset.x += (currentPosition.x - previousPosition.x) * speed;
			quadObject.renderer.material.mainTextureOffset = textureOffset;

			//	set the y position based on speed
			Vector3 newPosition = currentPosition;
			newPosition.y -= previousPosition.y * speed;

			//	update the parallax position
			transform.position = newPosition - offset;
			previousPosition = mainCamera.transform.position;
		}
	}
}
