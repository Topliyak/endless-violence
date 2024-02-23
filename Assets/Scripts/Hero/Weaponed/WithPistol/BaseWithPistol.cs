using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Hero.Weaponed.WithPistol
{
	public class BaseWithPistol : BaseWithWeapon<OneBulletGun>
	{
		[SerializeField] private PistolPoserSettings _poserSettings;

		private OnFootAimPoser_Pistol _poser;

		protected override void Awake()
		{
			base.Awake();
			_poser = GetComponent<OnFootAimPoser_Pistol>();
		}

		public override void BeforeShowWeapon()
		{
			var pistol = weapon.GetComponent<TwoHandHoldable>();
			_poser.Enable(pistol, _poserSettings);
		}

		private void OnDisable()
		{
			ForgetOrHideWeapon();
			_poser.Disable();
			animationWorker.Disable();
		}
	}
}
