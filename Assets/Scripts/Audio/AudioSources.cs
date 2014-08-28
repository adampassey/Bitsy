using UnityEngine;
using System.Collections.Generic;


namespace Bitsy.Audio {

	/**
	 * Attach multiple AudioClips to a single GameObject
	 * and play them using their index.
	 **/
	[AddComponentMenu("Audio/Audio Sources")]
	public class AudioSources : MonoBehaviour {

		public List<AudioClip> audioClips;
		private AudioSource[] audioSources;

		public void Awake() {

			audioSources = new AudioSource[audioClips.Count];

			for (int i = 0; i < audioClips.Count; i++) {
				AudioSource audioSource = gameObject.AddComponent<AudioSource>();
				audioSource.clip = audioClips[i];
				audioSources[i] = audioSource;
			}
		}

		/**
		 * Play the AudioSource at the given index.
		 * 
		 * @param pos The int index
		 * @return void
		 **/
		public void Play(int pos) {
			audioSources[pos].Play();
		}

		/**
		 * Play the AudioSource at the given index for
		 * a specific amount of time.
		 * 
		 * @param pos The int index
		 * @param time The double time
		 * @return void
		 **/
		public void PlayScheduled(int pos, double time) {
			audioSources[pos].PlayScheduled(time);
		}

		/**
		 * Stop playing the AudioSource at the given index.
		 * 
		 * @param pos The int index
		 * @return void
		 **/
		public void Stop(int pos) {
			audioSources[pos].Stop();
		}

		/**
		 * Play the AudioClip at the given index a single time.
		 * 
		 * @param pos The int index
		 * @return void
		 **/
		public void PlayOnce(int pos) {
			audioSources[pos].PlayOneShot(audioSources[pos].clip);
		}

		/**
		 * Play the AudioClip at the given index and volume scale.
		 * 
		 * @param pos The int index
		 * @param volumeScale The float volume scale
		 */
		public void PlayOnce(int pos, float volumeScale) {
			audioSources[pos].PlayOneShot(audioSources[pos].clip, volumeScale);
		}

		/**
		 * Retrieve the AudioSource at the given index
		 * 
		 * @parm int pos The int index
		 * @return AudioSource The audio source
		 **/
		public AudioSource GetAudioSource(int pos) {
			return audioSources[pos];
		}
	}
}
