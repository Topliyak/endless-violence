using MyInput;

namespace Hero.Weaponed.WithRifle
{
	public sealed class CrouchedAim_Rifle : BaseWithRifle
    {
		private void Update()
		{
			if (Input.crouched)
				TransitTo<OnFootAim_Rifle>();

			if (Input.aim == false)
				TransitTo<CrouchedDontAim_Rifle>();

			if (Input.fire)
				weapon.TryShoot();
		}
	}
}
