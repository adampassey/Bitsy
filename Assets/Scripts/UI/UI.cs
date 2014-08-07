using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.UserInterface
{
	public static class UI
	{
		public static void Draggable(InventoryPosition inventoryPosition, Vector2 guiPosition, int tilesize, InventoryItem inventoryItem, GameObject[,] inventory) {
			DraggableElement.Render(inventoryPosition, guiPosition, tilesize, inventoryItem, inventory);
		}

		public static void Droppable(InventoryPosition inventoryPosition, Vector2 guiPosition, int tilesize, GameObject[,] inventory, GameObject window) {
			DroppableElement.Render(inventoryPosition, guiPosition, tilesize, inventory, window);
		}
	}
}