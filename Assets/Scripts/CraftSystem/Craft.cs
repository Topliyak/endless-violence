using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Inventory;

namespace CraftSystem
{
	[RequireComponent(typeof(StorageWithResources))]
	public class Craft : MonoBehaviour
	{
		private StorageWithResources _storage;
		private Craftable _craftable;
		private float _startTime_sec;
		private List<Craftable.Ingredient> _ingredientsBuffer;

		public event UnityAction onStarted;
		public event UnityAction onFinished;
		public event UnityAction onPrevented;

		public bool inProcess => _craftable != null;

		public Craftable craftable => _craftable;

		private void Awake()
		{
			_ingredientsBuffer = new List<Craftable.Ingredient>();
			_storage = GetComponent<StorageWithResources>();
		}

		private void Update()
		{
			if (!inProcess)
				return;

			float timeSinceCraftStarted = Time.realtimeSinceStartup - _startTime_sec;

			if (timeSinceCraftStarted >= _craftable.craftTime_seconds)
				Finish();
		}

		public bool TryStart(Craftable craftable)
		{
			if (_storage.PlacesFor(craftable.resource) == 0)
			{
				print("Cant start craft. Not enough places");
				Prevent();
				return false;
			}

			bool ingredientsGotSuccess = TryGetIngredientsFor(craftable);

			if (!ingredientsGotSuccess)
			{
				print("Not enough ingredients");
				Prevent();
				return false;
			}

			_startTime_sec = Time.realtimeSinceStartup;
			_craftable = craftable;

			onStarted?.Invoke();

			return true;
		}

		private bool TryGetIngredientsFor(Craftable craftable)
		{
			foreach (var ingredient in craftable.ingredients)
			{
				bool ingredientGotSuccess = TryGetIngredient(ingredient);

				if (!ingredientGotSuccess)
					return false;
			}

			return true;
		}

		private bool TryGetIngredient(Craftable.Ingredient ingredient)
		{
			if (_storage.CountOf(ingredient.resource) < ingredient.amount)
				return false;

			_storage.Remove(ingredient.resource, ingredient.amount);
			_ingredientsBuffer.Add(ingredient);

			return true;
		}

		private void Finish()
		{
			_storage.Add(_craftable.resource, _craftable.craftedAmount);

			_craftable = null;
			_ingredientsBuffer.Clear();

			onFinished?.Invoke();
		}

		private void ReturnIngredientsToStorage()
		{
			foreach (var ingredient in _ingredientsBuffer)
				_storage.Add(ingredient.resource, ingredient.amount);

			_ingredientsBuffer.Clear();
		}

		public void Prevent()
		{
			_craftable = null;
			ReturnIngredientsToStorage();

			onPrevented?.Invoke();
		}
	}
}
