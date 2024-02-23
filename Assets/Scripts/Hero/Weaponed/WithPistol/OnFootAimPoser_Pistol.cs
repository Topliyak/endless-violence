using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Hero.Weaponed.WithPistol
{
	public class OnFootAimPoser_Pistol : MonoBehaviour
	{
		private TwoHandHoldable _pistol;
		private PistolPoserSettings _poserSettings;
		private Transform _rightHand;
		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_rightHand = _animator.GetBoneTransform(HumanBodyBones.RightHand);
		}

		private void FixedUpdate()
		{
			PosePistol();
		}

		private void OnAnimatorIK(int layerIndex)
		{
			Quaternion rightHandRotation = _pistol.transform.rotation * _poserSettings.rightHandRotationOffset;

			_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
			_animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandRotation);
		}

		private void PosePistol()
		{
			Vector3 position = _rightHand.TransformPoint(_poserSettings.pistolPositionInHand);
			_pistol.transform.position = position;
		}

		public void Enable(TwoHandHoldable pistol, PistolPoserSettings poserSettings)
		{
			_pistol = pistol;
			_poserSettings = poserSettings;

			_pistol.transform.parent = transform;
			_pistol.transform.localRotation = _poserSettings.pistolRotation;

			PosePistol();
			enabled = true;
		}

		public void Disable()
		{
			_pistol = null;
			_poserSettings = null;
			enabled = false;
		}
	}
}
