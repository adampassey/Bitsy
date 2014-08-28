using UnityEngine;
using System.Collections;

using Bitsy.Timer;

public class TimerUsage : MonoBehaviour {

	private Timer timer;

	void Start() {
		timer = new Timer();
	}

	// Update is called once per frame
	void Update() {
		if (timer.TimeHasPassed(10)) {
			Debug.Log("Time has passed.");
		}
	}
}
