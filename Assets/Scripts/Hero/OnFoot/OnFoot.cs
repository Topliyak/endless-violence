using UnityEngine;

namespace Hero
{
	[RequireComponent(typeof(OnFootAnimator))]
	[RequireComponent(typeof(CharacterController))]
	public sealed class OnFoot : State
	{
		private OnFootAnimator _animationWorker;
		private CharacterController _characterController;

		private void Awake()
		{
			_animationWorker = GetComponent<OnFootAnimator>();
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			if (MyInput.Input.crouched)
			{
				TransitTo<Crouched>();
			}

			if (MyInput.Input.fire)
			{
				TransitTo<Fight>();
			}
		}

		private void FixedUpdate()
		{
			if (_characterController.isGrounded == false)
			{
				TransitTo<Falling>();
			}
		}

		private void OnEnable()
		{
			_animationWorker.Enable();
		}

		private void OnDisable()
		{
			_animationWorker.Disable();
		}
	}
}
