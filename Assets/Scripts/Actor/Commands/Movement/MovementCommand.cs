using UnityEngine;
using System.Collections;

namespace Bitsy.Actor.Commands.MovementCommands {

	public abstract class MovementCommand : Command {

		public abstract void Execute(Actor actor);
		public abstract void Leave(Actor actor);

		/**
		 * 	Raycast to determine if the actor is grounded
		 * 
		 **/
		protected bool IsGrounded(Actor actor) {
			BoxCollider2D boxCollider = actor.GetComponent<BoxCollider2D>();
			if (boxCollider == null) {
				return false;
			}

			float lineCastDistance = 0.1f;

			Vector3 colliderCenter = Vector2.Scale(actor.transform.localScale, boxCollider.center);
			Vector3 colliderPosition = actor.transform.position + colliderCenter;
			Vector3 colliderSize = Vector2.Scale(actor.transform.localScale, boxCollider.size);

			Vector2 origin = actor.transform.position;
			origin.x = colliderPosition.x - (colliderSize.x / 2f);
			origin.y = colliderPosition.y - (colliderSize.y / 2f) - 0.05f; // don't collide with player
			Vector2 bottomLeftEnd = origin;
			bottomLeftEnd.y -= lineCastDistance;

			//	bottom left line
			Debug.DrawLine(origin, bottomLeftEnd, Color.blue, 1.0f);
			RaycastHit2D bottomLeftHit = Physics2D.Linecast(origin, bottomLeftEnd);

			origin.x = colliderPosition.x + (colliderSize.x / 2f);
			Vector2 bottomRightEnd = origin;
			bottomRightEnd.y -= lineCastDistance;

			//	bottom right line
			Debug.DrawLine(origin, bottomRightEnd, Color.blue, 1.0f);
			RaycastHit2D bottomRightHit = Physics2D.Linecast(origin, bottomRightEnd);

			return bottomLeftHit.collider != null || bottomRightHit.collider != null;
		}
	}
}
