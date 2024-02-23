using Weapons;
using MyInput;

namespace Hero.Weaponed.WithPistol
{
	public class CrouchedDontAim_Pistol : BaseDontAim<OneBulletGun>
	{
		private void Update()
		{
			if (Input.crouched)
				TransitTo<OnFootDontAim_Pistol>();

			if (Input.aim)
				TransitTo<CrouchedAim_Pistol>();
		}
	}
}