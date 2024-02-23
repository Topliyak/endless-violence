using UnityEngine;

namespace Hero
{
	public class CrouchedAnimationWorker : Animations.StateAnimator
	{
		public float axisTransitionSpeed;

		private Vector2 _axis;

		public override string stateParametr => AnimatorParameters.crouched;

		protected override void Awake()
		{
			base.Awake();

			_axis = Vector2.zero;
		}

		void Update()
		{
			_axis = Vector2.Lerp(_axis, MyInput.Input.axis.normalized, axisTransitionSpeed * Time.deltaTime);

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
