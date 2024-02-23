using UnityEngine;
using UnityEngine.Events;

namespace Hero
{
	[RequireComponent(typeof(CharacterController))]
	public class Gravity : MonoBehaviour
	{
		public float acceleration;

		private CharacterController _characterController;

		public event UnityAction landedEvent;

		public float velocity { get; private set; }

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		private void OnEnable()
		{
			velocity = 0;
		}

		private void FixedUpdate()
		{
			velocity += acceleration * Time.deltaTime;
			_characterController.Move(Vector3.up * velocity * Time.deltaTime);

			if (_characterController.isGrounded == true)
			{
				landedEvent?.Invoke();
				velocity = acceleration;
			}
		}
	}
}
