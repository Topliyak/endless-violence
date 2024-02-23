using UnityEngine;
using Weapons;
using Hero.Weaponed.PoserSettings;

namespace Hero.Weaponed.WithPistol
{
	public class CrouchedAimPoser_Pistol : MonoBehaviour
	{
		private TwoHandHoldable _pistol;
		private PoserSettingsFromShoulder _settings;
		private Transform _shoulder;
		private Animator _animator;

		private Vector3 _leftHandPos;
		private Quaternion _leftHandRot;
		private Vector3 _rightHandPos;
		private Quaternion _rightHandRot;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_shoulder = _animator.GetBoneTransform(HumanBodyBones.RightShoulder);
		}

		private void FixedUpdate()
		{
			PosePistol();
			UpdateHandPositions();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
			_animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandPos);

			_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
			_animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandRot);

			_animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
			_animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandPos);

			_animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
			_animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandRot);
		}

		private void UpdateHandPositions()
		{
			_leftHandPos = GetLeftHandPosition();
			_leftHandRot = GetLeftHandRotation();

			_rightHandPos = GetRightHandPosition();
			_rightHandRot = GetRightHandRotation();
		}

		private Vector3 GetRightHandPosition()
		{
			return GetHandPosition(_settings.rightHandOffsetFromRightHandRef, _pistol.RightHandRef);
		}

		private Quaternion GetRightHandRotation()
		{
			return GetHandRotation(_settings.rightHandRotationOffset, _pistol.RightHandRef);
		}

		private Vector3 GetLeftHandPosition()
		{
			return GetHandPosition(_settings.leftHandOffsetFromLeftHandRef, _pistol.LeftHandRef);
		}

		private Quaternion GetLeftHandRotation()
		{
			return GetHandRotation(_settings.leftHandRotationOffset, _pistol.LeftHandRef);
		}

		private Vector3 GetHandPosition(Vector3 offset, Transform reference)
		{
			return reference.TransformPoint(offset);
		}

		private Quaternion GetHandRotation(Quaternion offset, Transform reference)
		{
			return reference.rotation * offset;
		}

		private void PosePistol()
		{
			Vector3 offset = transform.TransformDirection(_settings.weaponOffsetFromShoulder);
			_pistol.transform.position = _shoulder.position + offset;
		}

		public void Enable(TwoHandHoldable pistol, PoserSettingsFromShoulder settings)
		{
			_settings = settings;
			_pistol = pistol;
			_pistol.transform.rotation = transform.rotation;
			PosePistol();
			enabled = true;
		}

		public void Disable()
		{
			_pistol = null;
			_settings = null;
			enabled = false;
		}
	}
}
