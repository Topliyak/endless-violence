using UnityEngine;

namespace Weapons
{
	public class TwoHandHoldable : MonoBehaviour
	{
		[SerializeField] private Transform _rightHandRef;
		[SerializeField] private Transform _leftHandRef;

		public Transform RightHandRef => _rightHandRef;

		public Transform LeftHandRef => _leftHandRef;
	}
}
