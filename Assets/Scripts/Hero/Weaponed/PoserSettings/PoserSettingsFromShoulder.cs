using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hero.Weaponed.PoserSettings
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/PoserFromShoulder")]
	public class PoserSettingsFromShoulder : ScriptableObject
	{
		[Header("Weapon")]
		[SerializeField] private Vector3 _weaponOffsetFromShoulder;

		[Header("Right Hand")]
		[SerializeField] private Vector3 _rightHandOffsetFromRightHandRef;
		[SerializeField] private Quaternion _rightHandRotationOffset;

		[Header("Left Hand")]
		[SerializeField] private Vector3 _leftHandOffsetFromLeftHandRef;
		[SerializeField] private Quaternion _leftHandRotationOffset;

		public Vector3 weaponOffsetFromShoulder => _weaponOffsetFromShoulder;

		public Vector3 rightHandOffsetFromRightHandRef => _rightHandOffsetFromRightHandRef;

		public Quaternion rightHandRotationOffset => _rightHandRotationOffset;

		public Vector3 leftHandOffsetFromLeftHandRef => _leftHandOffsetFromLeftHandRef;

		public Quaternion leftHandRotationOffset => _leftHandRotationOffset;
	}
}
