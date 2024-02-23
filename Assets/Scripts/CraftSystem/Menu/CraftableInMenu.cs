using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftSystem.Menu
{
	public class CraftableInMenu : MonoBehaviour
	{
		[SerializeField] private Craftable _craftable;
		[SerializeField] private TMPro.TMP_Text _craftedAmount;

		public Craftable craftable => _craftable;

		private void OnEnable()
		{
			_craftedAmount.text = $"x{_craftable.craftedAmount}";
		}
	}
}
