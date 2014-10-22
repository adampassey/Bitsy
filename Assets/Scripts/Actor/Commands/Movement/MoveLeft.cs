using UnityEngine;
using System.Collections;

namespace Bitsy.Actor.Commands.MovementCommands {

	public class MoveLeft : MovementCommand {

		public override void Execute(Actor actor) {
			actor.newPosition.x -= actor.movementSpeed;
		}

		public override void Leave(Actor actor) {
			Debug.Log("Leaving Move Left.");
		}
	}
}
