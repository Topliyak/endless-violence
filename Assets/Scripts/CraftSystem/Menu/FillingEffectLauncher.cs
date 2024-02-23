using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CraftSystem.Menu
{
	public class FillingEffectLauncher : MonoBehaviour
	{
		private CraftableInMenu[] _craftablesInMenu;
		private Craft _craft;
		private Other.FillingEffect _effect;

		private void Awake()
		{
			_craft = FindObjectOfType<Craft>();
			_craftablesInMenu = FindObjectsOfType<CraftableInMenu>();
		}

		private void OnEnable()
		{
			_craft.onStarted += StartEffect;
			_craft.onFinished += StopEffect;
			_craft.onPrevented += StopEffect;
		}

		private void OnDisable()
		{
			_craft.onStarted -= StartEffect;
			_craft.onFinished -= StopEffect;
			_craft.onPrevented -= StopEffect;
		}

		private void StartEffect()
		{
			var resource = _craft.craftable.resource;
			float duration = _craft.craftable.craftTime_seconds;

			_effect = (
				FindObjectsOfType<CraftableInMenu>().
				Where(c => c.craftable.resource == resource).First().
				GetComponentInChildren<Other.FillingEffect>()
			);

			_effect.Play(duration);
		}

		private void StopEffect()
		{
			if (_effect == null)
				return;

			_effect.Stop();
		}
	}
}
