using UnityEngine;

namespace Hero
{
	[RequireComponent(typeof(FallingAnimationWorker))]
	[RequireComponent(typeof(Gravity))]
	public sealed class Falling : State
	{
		private Animations.AnimationWorker _animationWorker;
		private Gravity _gravity;

		private void Awake()
		{
			_animationWorker = GetComponent<FallingAnimationWorker>();
			_gravity = GetComponent<Gravity>();
		}

		private void SwitchToOnFoot()
		{
			TransitTo<OnFoot>();
		}

		private void OnEnable()
		{
			_gravity.landedEvent += SwitchToOnFoot;
			_animationWorker.Enable();
		}

		private void OnDisable()
		{
			_gravity.landedEvent -= SwitchToOnFoot;
			_animationWorker.Disable();
		}
	}
}
