using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface.Handler
{
	/**
	 * 	A DraggableHandler will receive events from UI.Draggable elements
	 **/
	public interface DraggableHandler
	{
		void MouseDrag(UnityEngine.Event e);
		
		void MouseUp(UnityEngine.Event e);
		
	}
}
