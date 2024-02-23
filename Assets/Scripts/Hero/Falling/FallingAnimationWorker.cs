using UnityEngine;

namespace Hero
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(Gravity))]
	public class FallingAnimationWorker : Animations.StateAnimator
	{
		public float minVelocityForSoftLand;

		private Gravity _gravity;

		public override string stateParametr => AnimatorParameters.falling;

		protected override void Awake()
		{
			base.Awake();

			_gravity = GetComponent<Gravity>();
		}

		protected override void OnEnable()
		{
			_gravity.landedEvent += Land;
			TurnOnState();
		}

		protected override void OnDisable()
		{
			_gravity.landedEvent -= Land;
			TurnOffState();
		}

		private void Land()
		{
			if (_gravity.velocity <= minVelocityForSoftLand)
			{
				animator.SetTrigger(AnimatorParameters.hardLand);
			}
			else
			{
				animator.SetTrigger(AnimatorParameters.softLand);
			}
		}
	}
}
