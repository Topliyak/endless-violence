using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftSystem.Menu
{
	public class CraftLauncher : MonoBehaviour
	{
		[SerializeField] private float _timeUntilCraft_sec;
		
		private Craft _craft;
		private CraftableButtonsListener _craftableButtonsListener;
		private float _buttonDownMoment;
		private CraftableInMenu _craftableInMenu;

		private void Awake()
		{
			_craftableButtonsListener = GetComponentInChildren<CraftableButtonsListener>();
			_craft = FindObjectOfType<Craft>();
		}

		private void OnEnable()
		{
			_craftableButtonsListener.onButtonDown += OnButtonDown;
			_craftableButtonsListener.onButtonUp += OnButtonUp;

			_craft.onPrevented += ForgetCraftInMenu;
			_craft.onFinished += ForgetCraftInMenu;
		}

		private void OnDisable()
		{
			_craftableButtonsListener.onButtonDown -= OnButtonDown;
			_craftableButtonsListener.onButtonUp -= OnButtonUp;

			_craft.onPrevented -= ForgetCraftInMenu;
			_craft.onFinished -= ForgetCraftInMenu;
		}

		private void OnButtonDown(CraftableInMenu craftableInMenu)
		{
			_craftableInMenu = craftableInMenu;
			_buttonDownMoment = Time.realtimeSinceStartup;
		}

		private void OnButtonUp(CraftableInMenu craftableInMenu)
		{
			_craftableInMenu = null;

			if (_craft.inProcess)
				_craft.Prevent();
		}

		private void ForgetCraftInMenu()
		{
			_craftableInMenu = null;
		}

		private void Update()
		{
			if (_craftableInMenu == null || _craft.inProcess)
				return;

			if (Time.realtimeSinceStartup - _buttonDownMoment < _timeUntilCraft_sec)
				return;
			
			bool startedSuccess = _craft.TryStart(_craftableInMenu.craftable);
		}
	}
}
