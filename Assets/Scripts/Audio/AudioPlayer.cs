using UnityEngine;
using System.Collections;

namespace AdamPassey.Audio {

	/**
	 * 	A Singleton audio player
	 * 	Convenient for disabled items that want
	 * 	to play sounds.
	 * 
	 **/
	public class AudioPlayer : MonoBehaviour {

		private static AudioPlayer instance;
		private AudioSource audioSource;

		/**
		 * 	Retrieve the AudioPlayer
		 * 
		 **/
		public static AudioPlayer GetInstance() {
			if (instance == null) {
				GameObject go = new GameObject();
				go.name = "Audio Player";
				instance = go.AddComponent<AudioPlayer>();
				instance.audioSource = go.AddComponent<AudioSource>();
			}
			return instance;
		}

		/**
		 * 	Play the AudioClip one time
		 * 
		 * 	@param AudioClip clip The audio clip to play
		 * 
		 **/
		public void PlayOnce(AudioClip clip) {
			audioSource.clip = clip;
			audioSource.PlayOneShot(clip);
		}
	}
}
