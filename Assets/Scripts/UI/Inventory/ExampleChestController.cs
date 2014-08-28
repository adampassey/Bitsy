using UnityEngine;
using System.Collections;

using Bitsy.UserInterface.Inventory;

public class ExampleChestController : MonoBehaviour {

	private Inventory inventory;

	// Use this for initialization
	void Start() {
		inventory = gameObject.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.C)) {
			if (inventory.IsVisible()) {
				inventory.Hide();
			} else {
				inventory.Show();
			}

		}
	}
}
