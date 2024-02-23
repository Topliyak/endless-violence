using MyInput;

namespace Hero.Weaponed.WithPistol
{
	public class OnFootAim_Pistol : BaseWithPistol
	{
		private void Update()
		{
			if (Input.aim == false)
				TransitTo<OnFootDontAim_Pistol>();

			if (Input.crouched)
				TransitTo<CrouchedAim_Pistol>();

			if (Input.fire)
				weapon.TryShoot();
		}
	}
}
