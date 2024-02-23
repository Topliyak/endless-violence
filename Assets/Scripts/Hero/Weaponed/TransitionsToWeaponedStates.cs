using UnityEngine;
using Weapons;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Hero.Weaponed
{
	[RequireComponent(typeof(WeaponSwitcher))]
	[RequireComponent(typeof(StateSwitcher))]
	[RequireComponent(typeof(StateStory))]
	public class TransitionsToWeaponedStates : MonoBehaviour
	{
		[SerializeField] private List<Transition> _conditionAndStatePairs;

		private WeaponSwitcher _weaponSwitcher;
		private StateSwitcher _stateSwitcher;
		private StateStory _stateStory;

		private void Awake()
		{
			_weaponSwitcher = GetComponent<WeaponSwitcher>();
			_stateSwitcher = GetComponent<StateSwitcher>();
			_stateStory = GetComponent<StateStory>();
		}

		private void OnEnable()
		{
			_weaponSwitcher.weaponChanged += OnWeaponChanged;
		}

		private void OnDisable()
		{
			_weaponSwitcher.weaponChanged -= OnWeaponChanged;
		}

		private void OnWeaponChanged(GameObject weapon)
		{
			if (weapon == null)
				throw new NullReferenceException("Hero must have any weapon");

			State nextState = GetNextStateOrNull(weapon.tag, _stateStory[-1]);

			if (nextState != null)
				_stateSwitcher.TransitTo(nextState);
		}

		private State GetNextStateOrNull(string weaponTag, State prevState)
		{
			Transition transition = _conditionAndStatePairs.FirstOrDefault(t => t.StrictCompare(weaponTag, prevState));

			if (transition == null)
				transition = _conditionAndStatePairs.FirstOrDefault(t => t.NonStrictCompare(weaponTag, prevState));

			return transition?.To;
		}

		[Serializable]
		private class Transition
		{
			[SerializeField] private string _selectedWeaponTag;
			[SerializeField] private State _from;
			[SerializeField] private State _to;

			public Transition(string tag, State from, State to)
			{
				_selectedWeaponTag = tag;
				_from = from;
				_to = to;
			}

			public string SelectedWeaponTag => _selectedWeaponTag;

			public State From => _from;

			public State To => _to;

			public bool StrictCompare(string tag, State current)
			{
				return SelectedWeaponTag == tag && From == current;
			}

			public bool NonStrictCompare(string tag, State current)
			{
				return SelectedWeaponTag == tag && (From == null || From == current);
			}
		}
	}
}
