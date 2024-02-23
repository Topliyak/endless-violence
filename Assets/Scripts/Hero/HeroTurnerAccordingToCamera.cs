using UnityEngine;
using System.Linq;

namespace Hero
{
	[RequireComponent(typeof(StateSwitcher))]
	public class HeroTurnerAccordingToCamera : MonoBehaviour
	{
		[SerializeField] private float _turnSpeed;
		[SerializeField] private State[] _turnableStatuses;

		private StateSwitcher _statusSwitcher;
		private Transform _camera;

		private void Awake()
		{
			_statusSwitcher = GetComponent<StateSwitcher>();
			_camera = Camera.main.transform;
		}

		private void Update()
		{
			Quaternion newRotation = Quaternion.Euler(0, _camera.rotation.eulerAngles.y, 0);

			if (MyInput.Input.axis.sqrMagnitude > 0 && _turnableStatuses.Contains(_statusSwitcher.Current))
				transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, _turnSpeed * Time.deltaTime);
		}

		private void OnValidate()
		{
			if (_turnSpeed <= 0)
				throw new MyExceptions.ValidationExcepiton($"{nameof(_turnSpeed)} must be more than zero");
		}
	}
}
