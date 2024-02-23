using System.Linq;
using UnityEngine;
using Weapons;
using Animations;

namespace Hero.Weaponed.WithRifle
{
	[RequireComponent(typeof(RiflePoser))]
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(WeaponSwitcher))]
	[RequireComponent(typeof(StateReturnerAfterFalling))]
	public abstract class BaseWithRifle : BaseWithWeapon<OneBulletGun>
	{
		[SerializeField] private RiflePoserSettings _riflePoserSettings;

		private RiflePoser _riflePoser;

		protected override void Awake()
		{
			base.Awake();
			_riflePoser = GetComponent<RiflePoser>();
		}

		public override void BeforeShowWeapon()
		{
			var twoHandHoldable = weapon.GetComponent<TwoHandHoldable>();
			_riflePoser.Enable(twoHandHoldable, _riflePoserSettings);
		}

		private void OnDisable()
		{
			ForgetOrHideWeapon();
			animationWorker.Disable();
			_riflePoser.Disable();
		}
	}
}
