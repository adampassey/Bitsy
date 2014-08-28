using UnityEngine;
using System.Collections;

namespace Bitsy.Audio {

	public class AudioSourcesUsage : MonoBehaviour {

		private AudioSources audioSources;

		//	for better readability, define
		//	sounds via enum
		enum Sounds {
			Smack,
			Hit,
			Jump
		}

		public void Start() {
			audioSources = gameObject.GetComponent<AudioSources>();
		}

		public void Update() {

			//	play the individual AudioSources at
			//	their index on key input
			if (Input.GetKeyDown(KeyCode.A)) {
				audioSources.PlayOnce((int)Sounds.Smack);
			}

			if (Input.GetKeyDown(KeyCode.B)) {
				audioSources.PlayOnce((int)Sounds.Hit);
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				audioSources.PlayOnce((int)Sounds.Jump, 0.8f);
			}

			if (Input.GetKeyDown(KeyCode.D)) {
				audioSources.PlayScheduled((int)Sounds.Smack, 1);
			}

			if (Input.GetKeyDown(KeyCode.E)) {
				//	retrieve the AudioSource directly and manipulate
				AudioSource audioSource = audioSources.GetAudioSource((int)Sounds.Jump);
				audioSource.pitch = 0.5f;
				audioSource.dopplerLevel = 0.1f;

				audioSource.Play();
			}
		}
	}
}
