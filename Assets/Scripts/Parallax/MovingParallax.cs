using UnityEngine;
using System.Collections;

namespace AdamPassey.Parallax
{
	[AddComponentMenu("Environment/Moving Parallax")]
	public class MovingParallax : MonoBehaviour
	{

		public GameObject textureObject;
		public float speed = 0.1f;
	
		private Camera mainCamera;
		private Vector3 previousPosition;
		private Vector3 offset;

		// Use this for initialization
		void Start() {
			mainCamera = Camera.main;
			if (mainCamera == null) {
				Debug.LogError("Moving Parallax requires a main camera to work.");
			}
			
			offset = mainCamera.transform.position - transform.position;
		}
	
		// Update is called once per frame
		void Update() {

			//	TODO: this is duplicate code from the Parallax
			//	script. Create a shared component to handle the
			//	common functionality between Parallax components
			Vector3 currentPosition = mainCamera.transform.position;

			Vector2 textureOffset = textureObject.renderer.material.mainTextureOffset;
			textureOffset.x += speed * Time.deltaTime;
			textureObject.renderer.material.mainTextureOffset = textureOffset;

			Vector3 newPosition = currentPosition;
			newPosition.y -= previousPosition.y * speed;

			textureObject.transform.position = currentPosition - offset;
			previousPosition = mainCamera.transform.position;
		}
	}
}
