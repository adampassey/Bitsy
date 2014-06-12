using UnityEngine;
using System.Collections;

namespace AdamPassey.Audio
{
	public class AudioSourcesUsage : MonoBehaviour
	{

		private AudioSources audioSources;

		//	for better readability, define
		//	sounds via enum
		enum Sounds
		{
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
		}
	}
}
