using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace CraftSystem.Menu
{
	public class CraftableButtonsListener : MonoBehaviour
	{
		private Dictionary<GameObject, CraftableInMenu> _buttonsAndResources;
		private Other.Pointer[] _pointers;

		public event UnityAction<CraftableInMenu> onButtonDown;
		public event UnityAction<CraftableInMenu> onButtonUp;

		private void Awake()
		{
			_buttonsAndResources = new Dictionary<GameObject, CraftableInMenu>();

			foreach (var craftableInMenu in GetComponentsInChildren<CraftableInMenu>())
				_buttonsAndResources[craftableInMenu.gameObject] = craftableInMenu;

			_pointers = _buttonsAndResources.Keys.Select(b => b.GetComponent<Other.Pointer>()).ToArray();
		}

		private void OnEnable()
		{
			foreach (var button in _pointers)
			{
				button.onPointerDown += OnButtonDown;
				button.onPointerUp += OnButtonUp;
			}
		}

		private void OnDisable()
		{
			foreach (var button in _pointers)
			{
				button.onPointerDown -= OnButtonDown;
				button.onPointerUp -= OnButtonUp;
			}
		}

		private void OnButtonDown(GameObject button)
		{
			var craftableInMenu = _buttonsAndResources[button];
			onButtonDown?.Invoke(craftableInMenu);
		}

		private void OnButtonUp(GameObject button)
		{
			var craftableInMenu = _buttonsAndResources[button];
			onButtonUp?.Invoke(craftableInMenu);
		}
	}
}
