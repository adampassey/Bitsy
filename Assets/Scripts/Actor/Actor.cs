using UnityEngine;
using System.Collections;

namespace Bitsy.Actor {

	public class Actor : MonoBehaviour {

		//	movement attributes
		public float movementSpeed = 5f;
		public float movementInAirSpeed = 3f;
		public float jumpSpeed = 250f;

		//	used to render the new actor position
		//	on `FixedUpdate`
		public Vector3 newPosition;

		private Rigidbody2D _rigidbody;

		public void Start() {
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void Update() {
			transform.Translate(newPosition * Time.deltaTime);
			newPosition = Vector3.zero;
		}

		public void Jump() {
			_rigidbody.AddForce(new Vector3(0f, jumpSpeed, 0f));
		}
	}
}
