using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace CraftSystem.Menu
{
	public class InfoUpdater : MonoBehaviour
	{
		[SerializeField] private TMP_Text _title;
		[SerializeField] private TMP_Text _description;

		private CraftableButtonsListener _craftableButtonsListener;

		private void Awake()
		{
			_craftableButtonsListener = GetComponentInChildren<CraftableButtonsListener>();
		}

		private void OnEnable()
		{
			_craftableButtonsListener.onButtonDown += UpdateInfo;
		}

		private void OnDisable()
		{
			_craftableButtonsListener.onButtonDown -= UpdateInfo;
		}

		public void UpdateInfo(CraftableInMenu craftableInMenu)
		{
			var resource = craftableInMenu.craftable.resource;

			_title.text = resource.title;
			_description.text = resource.description;
		}
	}
}
