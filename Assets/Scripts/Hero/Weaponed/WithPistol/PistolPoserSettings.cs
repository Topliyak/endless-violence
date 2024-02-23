using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hero.Weaponed.WithPistol
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/PistolPoserSettings")]
	public class PistolPoserSettings : ScriptableObject
	{
		[Header("Pistol")]
		[SerializeField] private Vector3 _pistolPositionInHand;
		[SerializeField] private Quaternion _pistolRotation;

		[Header("RightHand")]
		[SerializeField] private Quaternion _rightHandRotationOffset;

		public Vector3 pistolPositionInHand => _pistolPositionInHand;

		public Quaternion pistolRotation => _pistolRotation;

		public Quaternion rightHandRotationOffset => _rightHandRotationOffset;
	}
}
