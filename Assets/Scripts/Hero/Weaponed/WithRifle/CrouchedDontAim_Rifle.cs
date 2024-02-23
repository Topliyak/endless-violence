using Weapons;
using MyInput;

namespace Hero.Weaponed.WithRifle
{
	public class CrouchedDontAim_Rifle : BaseDontAim<OneBulletGun>
	{
		private void Update()
		{
			if (Input.aim)
				TransitTo<CrouchedAim_Rifle>();

			if (Input.crouched)
				TransitTo<OnFootDontAim_Rifle>();
		}
	}
}
