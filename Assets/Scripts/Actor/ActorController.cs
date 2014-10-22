using UnityEngine;
using System.Collections;

using Bitsy.Actor.Commands.MovementCommands;

namespace Bitsy.Actor {

	public class ActorController : MonoBehaviour {

		//	movement commands
		private MoveLeft moveLeftCommand = new MoveLeft();
		private MoveRight moveRightCommand = new MoveRight();
		private Jump jumpCommand = new Jump();

		private Actor actor;

		public void Start() {
			actor = GetComponent<Actor>();
		}

		public void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				jumpCommand.Execute(actor);
			}

			if (Input.GetKey(KeyCode.A)) {
				moveLeftCommand.Execute(actor);
			}

			if (Input.GetKey(KeyCode.D)) {
				moveRightCommand.Execute(actor);
			}
		}
	}
}
