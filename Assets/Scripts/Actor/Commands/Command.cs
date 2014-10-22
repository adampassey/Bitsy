using UnityEngine;

namespace Bitsy.Actor.Commands {

	public interface Command {

		void Execute(Actor actor);
		void Leave(Actor actor);
	}
}

