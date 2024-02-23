using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Weapons
{
	public class WeaponSwitcher : MonoBehaviour
	{
		[SerializeField] private Transform _weaponsParent;
		[SerializeField] private List<GameObject> _weapons;

		private int _currentIndex = 0;

		public event UnityAction<GameObject> weaponChanged;

		public GameObject Current { get; private set; } = null;

		public IEnumerable<GameObject> Weapons => _weapons;

		private void Start()
		{
			Current = _weapons[_currentIndex];

			foreach (var weapon in _weapons)
				OnWeaponAdded(weapon);
		}

		private void Update()
		{
			if (_weapons.Count == 0)
				return;

			if (MyInput.Input.next)
				_currentIndex = (_currentIndex + 1) % _weapons.Count;

			if (MyInput.Input.previous)
				_currentIndex = (_currentIndex - 1 + _weapons.Count) % _weapons.Count;

			if (Current != _weapons[_currentIndex])
			{
				OnWeaponIndexChanged();
			}
		}

		public void SelectDefaultWeapon()
		{
			_currentIndex = 0;
			OnWeaponIndexChanged();
		}

		public void Add(GameObject weapon)
		{
			_weapons.Add(weapon);
			OnWeaponAdded(weapon);
		}

		private void OnWeaponAdded(GameObject weapon)
		{
			LinkWithWeaponParent(weapon);
			weapon.SetActive(false);

			if (_weapons.Count == 1)
			{
				_currentIndex = 0;
				OnWeaponIndexChanged();
			}
		}

		private void OnWeaponIndexChanged()
		{
			Hide();
			Current = _weapons[_currentIndex];
			weaponChanged?.Invoke(Current);
		}

		private void LinkWithWeaponParent(GameObject weapon)
		{
			weapon.transform.parent = _weaponsParent;
		}

		public void Hide()
		{
			Current.SetActive(false);
		}

		public void Show()
		{
			Current.SetActive(true);
		}

		private void OnValidate()
		{
			if (_weapons.Contains(null))
				throw new UnassignedReferenceException("Weapon can't be a null");

			if (_weaponsParent == null)
				throw new UnassignedReferenceException("Weapons parrent can't be a null");

			if (_weapons.Count == 0)
				throw new UnassignedReferenceException("Hero must have some weapon");
		}
	}
}
