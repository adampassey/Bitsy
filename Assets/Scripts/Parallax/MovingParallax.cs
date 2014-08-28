using UnityEngine;
using System.Collections;

namespace AdamPassey.Parallax {

	[AddComponentMenu("Environment/Moving Parallax")]
	public class MovingParallax : Parallax {

		// Use this for initialization
		public override void Start() {
			base.Start();
		}
	
		// Update is called once per frame
		public override void Update() {
			Vector3 currentPosition = mainCamera.transform.position;

			Vector2 textureOffset = materialObject.renderer.material.mainTextureOffset;
			textureOffset.x += speed * Time.deltaTime;
			materialObject.renderer.material.mainTextureOffset = textureOffset;

			Vector3 newPosition = currentPosition;
			newPosition.y -= previousPosition.y * speed;

			materialObject.transform.position = currentPosition - offset;
			previousPosition = currentPosition;
		}
	}
}
