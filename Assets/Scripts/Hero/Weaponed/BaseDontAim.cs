using System.Linq;
using UnityEngine;

namespace Hero.Weaponed
{
	public abstract class BaseDontAim<Weapon> : BaseWithWeapon<Weapon> where Weapon: MonoBehaviour
	{
		[SerializeField] private Vector3 _weaponPositionInHand;
		[SerializeField] private Quaternion _weaponRotationInHand;

		private Transform _rightHand;

		protected override void Awake()
		{
			base.Awake();
			_rightHand = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightHand);
		}

		public override void BeforeShowWeapon()
		{
			weapon.transform.parent = _rightHand;
			weapon.transform.localPosition = _weaponPositionInHand;
			weapon.transform.localRotation = _weaponRotationInHand;
		}

		public void RecordWeaponTransform()
		{
			_weaponPositionInHand = weapon.transform.localPosition;
			_weaponRotationInHand = weapon.transform.localRotation;
		}
	}
}
