using MyInput;
using Weapons;
using Hero.Weaponed.PoserSettings;

namespace Hero.Weaponed.WithPistol
{
	public class CrouchedAim_Pistol : BaseWithWeapon<OneBulletGun>
	{
		[UnityEngine.SerializeField] private PoserSettingsFromShoulder _poserSettings;

		public CrouchedAimPoser_Pistol poser { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			poser = GetComponent<CrouchedAimPoser_Pistol>();
		}

		private void Update()
		{
			if (Input.aim == false)
				TransitTo<CrouchedDontAim_Pistol>();

			if (Input.crouched)
				TransitTo<OnFootAim_Pistol>();

			if (Input.fire)
				weapon.TryShoot();
		}

		public override void BeforeShowWeapon()
		{
			var twoHandHoldable = weapon.GetComponent<TwoHandHoldable>();
			poser.Enable(twoHandHoldable, _poserSettings);
		}

		private void OnDisable()
		{
			weapon.transform.parent = weaponHolder;
			ForgetOrHideWeapon();
			animationWorker.Disable();
			poser.Disable();
		}
	}
}
