using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public float speed = 25f;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {

		Vector2 newPosition = new Vector2();

		if (Input.GetKey(KeyCode.LeftArrow)) {
			newPosition.x -= 1.0f;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			newPosition.x += 1.0f;
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			newPosition.y += 1.0f;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			newPosition.y -= 1.0f;
		}

		transform.Translate(newPosition * speed * Time.deltaTime);
	}
}
