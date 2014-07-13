using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.GameState;

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

		GameState.SetState(GameState.States.Running);
	}
	
	// Update is called once per frame
	void Update() {

		//	if we're paused, don't
		//	run the update loop
		if (!GameState.IsRunning()) {
			return;
		}

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

		if (Input.GetKeyDown(KeyCode.U)) {
			animator.SetBool("Unsheathe", true);
		}

		if (Input.GetKeyDown(KeyCode.O)) {
			//	Currently behaving as FILO
			GameObject obj = inventory.GetObject(0);
			if (obj != null) {
				Vector2 position = transform.position;
				position.x += 1f;
				obj.transform.position = position;
			}
		}

		if (Input.GetKeyDown(KeyCode.I)) {
			if (inventory.IsVisible()) {
				inventory.Hide();
			} else {
				inventory.Show();
			}
		}

		if (Input.GetKeyDown(KeyCode.T)) {
			if (Time.timeScale == 1.0f) {
				Time.timeScale = 0.5f;
			} else {
				Time.timeScale = 1.0f;
			}
		}
		
		transform.Translate(newPosition * speed * Time.deltaTime);
	}

	public void OnCollisionEnter2D(Collision2D collision) {
		InventoryItem inventoryItem = collision.gameObject.GetComponent<InventoryItem>();
		if (inventoryItem != null) {
			inventory.AddObject(inventoryItem.gameObject);
		}
	}
}
