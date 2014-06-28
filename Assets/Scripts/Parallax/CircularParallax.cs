using UnityEngine;
using System.Collections;

namespace AdamPassey.Parallax
{
	[AddComponentMenu("Environment/Circular Parallax")]
	public class CircularParallax : MonoBehaviour
	{
		public GameObject spriteRendererObject;
		public float rotationSpeed;
		public Vector3 rotationOffset;

		private Camera mainCamera;
		private Vector3 mainCameraOffset;
		private SpriteRenderer spriteRenderer;

		// Use this for initialization
		void Start() {

			//	grab the main camera
			mainCamera = Camera.main;
			if (mainCamera == null) {
				Debug.LogError("Circular Parallax requires a main camera to work.");
			}

			//	grab the camera offset
			mainCameraOffset = transform.position - mainCamera.transform.position;

			//	initialize the sprite renderer
			spriteRenderer = spriteRendererObject.GetComponent<SpriteRenderer>();
			if (spriteRenderer == null) {
				Debug.LogError("Cicrular Parallax requires a sprite renderer to work.");
			}
		}
	
		// Update is called once per frame
		void Update() {
			transform.position = mainCamera.transform.position + mainCameraOffset + rotationOffset;
			spriteRenderer.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.World);
		}
	}
}
