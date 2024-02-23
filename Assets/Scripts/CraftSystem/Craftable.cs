using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CraftSystem
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Craft/Craftable")]
	public class Craftable : ScriptableObject
	{
		[SerializeField] private Resource _resource;
		[SerializeField] private float _craftTime_seconds;
		[SerializeField] private int _craftedAmount;
		[SerializeField] private Ingredient[] _ingredients;

		public Resource resource => _resource;

		public float craftTime_seconds => _craftTime_seconds;

		public int craftedAmount => _craftedAmount;

		public IEnumerable<Ingredient> ingredients => _ingredients;

		[Serializable]
		public class Ingredient
		{
			[SerializeField] private Resource _resource;
			[SerializeField] private int _amount;

			public Resource resource => _resource;

			public int amount => _amount;
		}
	}
}
