using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

	public float speed = 5f;
	private Animator animator;

	// Use this for initialization
	void Start() {
		animator = gameObject.GetComponent<Animator>();
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

		if (Input.GetKey(KeyCode.U)) {
			animator.SetBool("Unsheathe", true);
		}
		
		transform.Translate(newPosition * speed * Time.deltaTime);
	}
}
