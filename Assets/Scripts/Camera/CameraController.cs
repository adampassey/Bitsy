using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float smoothing = 5f;
	public GameObject target;

	private Vector3 offset;

	// Use this for initialization
	void Start() {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update() {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag("Player");
		}
		
		transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * smoothing);
	}
}
