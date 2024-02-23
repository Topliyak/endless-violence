using UnityEngine;
using Weapons;

namespace Hero.Weaponed.WithRifle
{
	[RequireComponent(typeof(WeaponSwitcher))]
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(StateReturnerAfterFalling))]
	public sealed class OnFootDontAim_Rifle : BaseDontAim<OneBulletGun>
	{
		private void Update()
		{
			if (MyInput.Input.aim)
				TransitTo<OnFootAim_Rifle>();

			if (MyInput.Input.crouched)
				TransitTo<CrouchedDontAim_Rifle>();
		}

		[ContextMenu("Record Weapon Transform")]
		public new void RecordWeaponTransform() => base.RecordWeaponTransform();
	}
}
