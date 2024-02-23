using UnityEngine;
using Animations;

namespace Hero
{
	public abstract class MovingStateAnimator : StateAnimator
	{
		[SerializeField] private float _lerpRate;

		private Vector2 _axis = Vector2.zero;

		private void Update()
		{
			_axis = Vector2.Lerp(_axis, MyInput.Input.axis.normalized, _lerpRate * Time.deltaTime);

			animator.SetFloat(AnimatorParameters.horizontal, _axis.x);
			animator.SetFloat(AnimatorParameters.vertical, _axis.y);
		}
	}
}
