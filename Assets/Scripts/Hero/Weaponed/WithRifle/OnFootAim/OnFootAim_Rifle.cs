using MyInput;

namespace Hero.Weaponed.WithRifle
{
	public sealed class OnFootAim_Rifle : BaseWithRifle
	{
		private void Update()
		{
			if (Input.aim == false)
				TransitTo<OnFootDontAim_Rifle>();

			if (Input.fire)
				weapon.TryShoot();

			if (Input.crouched)
				TransitTo<CrouchedAim_Rifle>();
		}
	}
}
