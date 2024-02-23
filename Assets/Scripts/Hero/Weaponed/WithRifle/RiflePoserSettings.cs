using UnityEngine;

namespace Hero.Weaponed.WithRifle
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/RiflePoserSettings")]
	public class RiflePoserSettings : ScriptableObject
	{
		[Header("Rifle")]
		[SerializeField] private Vector3 _riflePositionOffset;
		[SerializeField] private Quaternion _rifleRotation;

		[Header("Right Hand")]
		[SerializeField] private Quaternion _rightHandRotationOffset;

		[Header("Left Hand")]
		[SerializeField] private Vector3 _leftHandPositionOffset;
		[SerializeField] private Quaternion _leftHandRotationOffset;

		public Vector3 RiflePositionOffset => _riflePositionOffset;

		public Quaternion RifleRotation => _rifleRotation;

		public Quaternion RightHandRotationOffset => _rightHandRotationOffset;

		public Vector3 LeftHandPositionOffset => _leftHandPositionOffset;

		public Quaternion LeftHandRotationOffset => _leftHandRotationOffset;
	}
}
