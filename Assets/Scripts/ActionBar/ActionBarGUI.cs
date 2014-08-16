using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;

namespace AdamPassey.ActionBar
{
	public class ActionBarGUI : MonoBehaviour
	{
		private ActionItem[] items;
		private ActionBar actionBar;
		private Vector2 offset;
		private int tilesize;
		private Rect windowRect = new Rect(0, 0, 500, 50);

		public static ActionBarGUI CreateComponent(GameObject parent, ActionBar actionBar, ActionItem[] items, Vector2 offset, int tilesize) {
			ActionBarGUI actionBarGUI = parent.AddComponent<ActionBarGUI>();
			actionBarGUI.actionBar = actionBar;
			actionBarGUI.items = items;
			actionBarGUI.offset = offset;
			actionBarGUI.tilesize = tilesize;
			return actionBarGUI;
		}

		public void OnGUI() {
			//	using the Instance ID as the window ID
			windowRect = GUI.Window(gameObject.GetInstanceID(), windowRect, OnActionBarGUI, "");
		}

		/**
		 * 	Render the Action Bar
		 * 
		 **/
		public void OnActionBarGUI(int windowId) {
			for (int i = 0; i < items.Length; i++) {
				if (items[i] != null) {
					ActionDraggableHandler handler = new ActionDraggableHandler(this.gameObject, items, i);
					UI.Draggable(new Rect((i * (float)tilesize) - tilesize, 0, tilesize, tilesize), items[i].GetGUIContent(), new GUIStyle("button"), handler);
				} else {
					ActionSlotHandler handler = new ActionSlotHandler(this.gameObject, items, i);
					UI.Slot(new Rect((i * (float)tilesize) - tilesize, 0, tilesize, tilesize), new GUIStyle("button"), handler, new GUIContent(i.ToString()));
				}
			}
		}

	}
}
