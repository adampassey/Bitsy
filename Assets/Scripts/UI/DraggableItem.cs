using UnityEngine;
using System.Collections;

using Bitsy.Audio;

namespace Bitsy.UserInterface {

	public class DraggableItem : MonoBehaviour {

		public Texture2D texture;
		public string itemName;
		public string description;

		private AudioSources audioSources;
		
		public virtual void Start() {
			audioSources = GetComponent<AudioSources>();
		}

		/**
		 * 	Called when the item is picked up
		 * 
		 **/
		public virtual void Pickup() {
			PlaySound(0);
		}

		/**
		 * 	Called when the item is put down
		 * 	(placed into an open slot)
		 * 
		 **/
		public virtual void PutDown() {
			PlaySound(1);
		}

		/**
		 * 	Called when the item is dropped
		 * 	TODO: not currently
		 **/
		public virtual void Drop() {
			PlaySound(2);
		}

		/**
		 * 	The GUI Content to display in UI
		 **/
		public virtual GUIContent GetGUIContent() {
			GUIContent guiContent = new GUIContent();
			guiContent.tooltip = itemName;
			guiContent.image = texture;
			
			return guiContent;
		}

		/**
		 * 	Drop this item
		 * 
		 **/
		public virtual bool Drop(Vector2 pos) {
			gameObject.transform.position = pos;
			gameObject.SetActive(true);
			gameObject.transform.parent = null;
			return true;
		}

		/**
		 * 	Play a sound if an AudioSources component is
		 * 	attached
		 * 
		 **/
		private void PlaySound(int index) {
			if (audioSources != null) {
				AudioSource.PlayClipAtPoint(audioSources.audioClips[index], transform.position);
			}
		}
	}
}
