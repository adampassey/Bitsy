using UnityEngine;
using System.Collections;
using AdamPassey.Inventory;

public class ActorController : MonoBehaviour
{

	public float speed = 5f;
	private Animator animator;
	private Rigidbody2D rigidbody;
	private Inventory inventory;

	// Use this for initialization
	void Start() {
		animator = gameObject.GetComponent<Animator>();
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		inventory = gameObject.GetComponent<Inventory>();
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
			rigidbody.AddForce(new Vector2(0f, 50f));
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			newPosition.y -= 1.0f;
		}

		if (Input.GetKey(KeyCode.U)) {
			animator.SetBool("Unsheathe", true);
		}

		if (Input.GetKeyDown(KeyCode.I)) {
			//	Currently behaving as FILO
			GameObject obj = inventory.GetObject(0);
			if (obj != null) {
				Vector2 position = transform.position;
				position.x += 1f;
				obj.transform.position = position;
			}
		}
		
		transform.Translate(newPosition * speed * Time.deltaTime);
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("OnTriggerEnter2D!");
		InventoryItem inventoryItem = collider.gameObject.GetComponent<InventoryItem>();
		if (inventoryItem != null) {
			inventory.AddObject(inventoryItem.gameObject);
		}
	}
}
