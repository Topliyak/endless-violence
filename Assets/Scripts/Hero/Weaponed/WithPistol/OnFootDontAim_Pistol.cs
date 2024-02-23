using Weapons;
using MyInput;

namespace Hero.Weaponed.WithPistol
{
	public sealed class OnFootDontAim_Pistol : BaseDontAim<OneBulletGun>
	{
		private void Update()
		{
			if (Input.aim)
				TransitTo<OnFootAim_Pistol>();

			if (Input.crouched)
				TransitTo<CrouchedDontAim_Pistol>();
		}

		[UnityEngine.ContextMenu("Record Weapon Transform")]
		public new void RecordWeaponTransform() => base.RecordWeaponTransform();
	}
}
