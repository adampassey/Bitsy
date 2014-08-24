using UnityEngine;
using System.Collections;

namespace AdamPassey.Parallax {

	[AddComponentMenu("Environment/Circular Parallax")]
	public class CircularParallax : Parallax {

		public float rotationSpeed;
		public Vector3 rotationOffset;

		// Use this for initialization
		public override void Start() {
			base.Start();
		}
	
		// Update is called once per frame
		public override void Update() {
			transform.position = mainCamera.transform.position - offset + rotationOffset;
			materialObject.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.World);
		}
	}
}
