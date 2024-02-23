using UnityEngine;
using Weapons;

namespace Hero.Weaponed.WithRifle
{
	[RequireComponent(typeof(Animator))]
	public class RiflePoser : MonoBehaviour
	{
		private RiflePoserSettings _riflePoserSettings;
		private TwoHandHoldable _rifle;
		private Animator _animator;
		private Transform _rightHand;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_rightHand = _animator.GetBoneTransform(HumanBodyBones.RightHand);
		}

		private void FixedUpdate()
		{
			PoseRifle();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			Quaternion leftHandRotation = _rifle.LeftHandRef.rotation * _riflePoserSettings.LeftHandRotationOffset;
			Quaternion rightHandRotation = _rifle.transform.rotation * _riflePoserSettings.RightHandRotationOffset;

			_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
			_animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandRotation);

			_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
			_animator.SetIKPosition(AvatarIKGoal.LeftHand, GetLeftHandPosition());

			_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
			_animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandRotation);
		}

		private void PoseRifle()
		{
			_rifle.transform.position = GetPositionForRifle();
		}

		private Vector3 GetPositionForRifle()
		{
			Vector3 offset = _rifle.transform.TransformVector(_riflePoserSettings.RiflePositionOffset);
			
			return _rightHand.position + offset;
		}

		private Vector3 GetLeftHandPosition()
		{
			Vector3 offset = _rifle.LeftHandRef.TransformVector(_riflePoserSettings.LeftHandPositionOffset);

			return _rifle.LeftHandRef.position + offset;
		}

		public void Enable(TwoHandHoldable rifle, RiflePoserSettings riflePoserSettings)
		{
			_riflePoserSettings = riflePoserSettings;
			_rifle = rifle;
			_rifle.transform.parent = transform;
			_rifle.transform.localRotation = _riflePoserSettings.RifleRotation;
			enabled = true;
			PoseRifle();
		}

		public void Disable()
		{
			enabled = false;
			_rifle = null;
			_riflePoserSettings = null;
		}
	}
}
