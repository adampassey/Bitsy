﻿using UnityEngine;
using System.Collections;

namespace AdamPassey.Animation
{
	public class AnimationSync : MonoBehaviour
	{

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
			AnimationInfo[] animationInfo = animator.GetCurrentAnimationClipState(0);
			string clipName = string.Empty;

			foreach (AnimationInfo ai in animationInfo) {
				if (ai.clip.isLooping) {
					clipName = ai.clip.name;
					break;
				}
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
		}

		/**
		 * 	Plays the current clip on all children animators
		 * 
		 **/
		private void PropagateAnimation() {
			foreach (Animator animator in childAnimators) {
				animator.Play(currentClipName);
			}
		}
	}
}