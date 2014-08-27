using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.UserInterface.Handler;
using AdamPassey.Audio;

namespace AdamPassey.UserInterface.Element {

	public static class Slot {

		private static DraggedItem draggedItem;

		static Slot() {
			draggedItem = DraggedItem.GetInstance();
		}
		/**
		 * 	Draw an open inventory slot
		 **/
		public static void Render(Rect position, GUIStyle guiStyle, SlotHandler handler, GUIContent guiContent) {
			//	create the rendering rect to serve as the rendering position 
			//	and the event-receiving area
			GUI.Box(position, guiContent, guiStyle);
			
			//	if the mouse is over this element
			if (position.Contains(UnityEngine.Event.current.mousePosition)) {

				//	fire the hover event on the handler
				if (draggedItem.item != null) {
					handler.Hover();
				}

				//	fire the mouse-up event on the handler
				if (UnityEngine.Event.current.type == EventType.MouseUp && draggedItem.item != null) {
					if (handler.ItemDropped(draggedItem.item)) {
						AudioSources audio = draggedItem.item.GetComponent<AudioSources>();
						if (audio != null) {
							AudioPlayer audioPlayer = AudioPlayer.GetInstance();
							audioPlayer.PlayOnce(audio.audioClips[1]);
						}
						draggedItem.item = null;
					}
					UnityEngine.Event.current.Use();
				}
			}
		}
	}
}
