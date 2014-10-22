using UnityEngine;
using System.Collections;

namespace Bitsy.Actor.Commands.MovementCommands {
	
	public class Jump : MovementCommand {
		
		public override void Execute(Actor actor) {
			if (IsGrounded(actor)) {
				actor.Jump();
			}
		}

		public override void Leave(Actor actor) {
			Debug.Log("Leaving Jump.");
		}
	}
}
