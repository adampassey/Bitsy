using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.GameState;
using AdamPassey.UI;

public class ActorController : MonoBehaviour
{

	public float speed = 5f;
	public GameObject collidedInventoryItem;

	private Animator animator;
	private Rigidbody2D rigidbody;
	private Inventory inventory;
	private Popup popup;

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

		if (Input.GetKeyDown(KeyCode.P) && collidedInventoryItem != null) {
			inventory.AddObject(collidedInventoryItem);
			collidedInventoryItem = null;
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

	public void OnGUI() {
		if (collidedInventoryItem != null) {
			if (popup == null) {
				popup = gameObject.AddComponent<Popup>();
				popup.content = "Press 'P' button to pickup " + collidedInventoryItem.name;
				popup.objectPosition = transform.position;
			}
		} else {
			Destroy(gameObject.GetComponent<Popup>());
			popup = null;
		}
	}

}
