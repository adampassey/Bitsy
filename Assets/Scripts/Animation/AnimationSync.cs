using UnityEngine;
using System.Collections;

namespace Bitsy.Animation {

	public class AnimationSync : MonoBehaviour {

		private string currentClipName;
		private Animator animator;
		private Animator[] childAnimators;

		/**
		 * 	On Start, retrieve both the animator on this gameObject
		 * 	as well as all child animators
		 * 
		 **/
		public void Start() {
			animator = gameObject.GetComponent<Animator>();
			childAnimators = GetComponentsInChildren<Animator>();
		}
	
		/**
		 * 	On Update, get the current clip name from the 
		 * 	animation state. If it has changed, trigger the
		 * 	child propagation
		 * 
		 **/
		public void Update() {
			AnimatorClipInfo[] animationInfo = animator.GetCurrentAnimatorClipInfo(0);
			string clipName = string.Empty;

			if (animationInfo.Length > 0) {
				clipName = animationInfo[0].clip.name;
			}

			if (currentClipName != clipName) {
				currentClipName = clipName;
				PropagateAnimation();
			}
		}

		/**
		 * 	If any children animators are added or removed
		 * 	call this to reload them
		 * 
		 **/
		public void ReloadChildAnimators() {
			childAnimators = GetComponentsInChildren<Animator>();

			//	setting to null so all new animators
			//	sync from the frame they're reloaded
			currentClipName = null;
		}

		/**
		 * 	Plays the current clip on all children animators
		 * 
		 **/
		private void PropagateAnimation() {
			foreach (Animator animator in childAnimators) {
				//	TODO: if this animator doesn't have the 
				//	currentClipName, this fails.
				animator.Play(currentClipName);
			}
		}
	}
}
