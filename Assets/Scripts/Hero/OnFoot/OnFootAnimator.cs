using UnityEngine;

namespace Hero
{
	public class OnFootAnimator : Animations.StateAnimator
	{
		public float axisTransitionSpeed;

		private Vector2 _axis;

		public override string stateParametr => AnimatorParameters.onFoot;

		protected override void Awake()
		{
			base.Awake();

			_axis = Vector2.zero;
		}

		protected override void OnEnable()
		{
			OnValidate();
			TurnOnState();
		}

		private void Update()
		{
			float multiplyer = MyInput.Input.sprinting ? 2 : 1;
			Vector2 inputAxis = MyInput.Input.axis.normalized * multiplyer;

			_axis = Vector2.Lerp(_axis, inputAxis, axisTransitionSpeed * Time.deltaTime);

			animator.SetFloat(AnimatorParameters.horizontal, _axis.x);
			animator.SetFloat(AnimatorParameters.vertical, _axis.y);
		}

		private void OnValidate()
		{
			if (axisTransitionSpeed <= 0)
				throw new MyExceptions.ValidationExcepiton($"{nameof(axisTransitionSpeed)} must be more than zero");
		}
	}
}
