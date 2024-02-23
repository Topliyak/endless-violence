using UnityEngine;

namespace Hero
{
	[RequireComponent(typeof(CrouchedAnimationWorker))]
	[RequireComponent(typeof(CharacterController))]
	public sealed class Crouched : State
	{
		private Animations.AnimationWorker _animationWorker;
		private CharacterController _characterController;

		private void Awake()
		{
			_animationWorker = GetComponent<CrouchedAnimationWorker>();
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			if (MyInput.Input.crouched)
			{
				TransitTo<OnFoot>();
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
