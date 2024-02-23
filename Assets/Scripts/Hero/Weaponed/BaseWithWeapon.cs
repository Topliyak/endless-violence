using System.Linq;
using UnityEngine;
using Animations;
using Weapons;

namespace Hero.Weaponed
{
	public abstract class BaseWithWeapon<Weapon>: State where Weapon: MonoBehaviour
	{
		[SerializeField] private AnimationWorker _animationWorker;

		private bool _forgetWeapon;

		public AnimationWorker animationWorker => _animationWorker;

		public Weapon weapon { get; private set; }

		public WeaponSwitcher weaponSwitcher { get; private set; }

		public CharacterController characterController { get; private set; }

		public StateReturnerAfterFalling stateReturnerAfterFalling { get; private set; }

		public Transform weaponHolder { get; private set; }

		protected virtual void Awake()
		{
			weaponSwitcher = GetComponent<WeaponSwitcher>();
			characterController = GetComponent<CharacterController>();
			stateReturnerAfterFalling = GetComponent<StateReturnerAfterFalling>();
			weaponHolder = transform.GetComponentsInChildren<Transform>().First(t => t.CompareTag(Tags.weaponHolder));
		}

		private void FixedUpdate()
		{
			if (characterController.isGrounded == false)
				OnNotGrounded();
		}

		private void OnEnable()
		{
			TakeWeapon();
			BeforeShowWeapon();
			weaponSwitcher.Show();
			animationWorker.Enable();
		}

		private void OnDisable()
		{
			weapon.transform.parent = weaponHolder;
			ForgetOrHideWeapon();
			animationWorker.Disable();
		}

		public void OnNotGrounded()
		{
			_forgetWeapon = false;
			stateReturnerAfterFalling.RecordStateForReturn(this);
			TransitTo<Falling>();
		}

		public void TakeWeapon()
		{
			weapon = weaponSwitcher.Current.GetComponent<Weapon>();

			if (weapon == null)
				throw new System.NullReferenceException($"This state cant work without {nameof(Weapon)}");

			_forgetWeapon = true;

			BeforeShowWeapon();

			weaponSwitcher.Show();
			animationWorker.Enable();
		}

		public abstract void BeforeShowWeapon();

		public void ForgetOrHideWeapon()
		{
			if (_forgetWeapon)
				weapon = null;
			else
				weaponSwitcher.Hide();
		}
	}
}
