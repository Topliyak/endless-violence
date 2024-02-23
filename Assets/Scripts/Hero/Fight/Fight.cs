using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hero
{
	public sealed class Fight : State
	{
		private bool _nextKickLocked;
		private bool _nextKick;
		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void OnEnable()
		{
			_animator.SetBool(AnimatorParameters.fight, true);
		}

		private void OnDisable()
		{
			_animator.SetBool(AnimatorParameters.fight, false);
		}

		private void Update()
		{
			if (MyInput.Input.fire)
				TryNextKick();
		}

		// Call from animation event
		public void OnKickStarted()
		{
			_nextKickLocked = true;
			_animator.SetBool(AnimatorParameters.fight, false);
		}

		// Call from animation event
		public void OnKicked()
		{
			_nextKickLocked = false;
			_nextKick = false;
		}

		// Call from animation event
		public void OnKickFinished()
		{
			if (_nextKick == false)
				TransitTo<OnFoot>();
		}

		public bool TryNextKick()
		{
			if (_nextKickLocked)
				return false;

			_animator.SetBool(AnimatorParameters.fight, true);
			_nextKick = true;

			return true;
		}
	}
}
