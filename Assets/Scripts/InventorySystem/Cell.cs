using System;
using UnityEngine;
using CraftSystem;

namespace Inventory
{
	[Serializable]
	public class Cell
	{
		[SerializeField] private Resource _resource;
		[SerializeField] private int _amount;
		[SerializeField] private int _limit;

		public Resource resource => _resource;

		public int amount => _amount;

		public int limit => _limit;

		public int freePlaces => _limit - _amount;

		public void Increase(int additionalAmount)
		{
			if (additionalAmount > freePlaces)
				throw new ArgumentException("Don't have enought free places");

			_amount += additionalAmount;
		}

		public int TryIncreaseAndReturnExtra(int additionalAmout)
		{
			int availableToAdd = Mathf.Min(freePlaces, additionalAmout);
			Increase(availableToAdd);

			return additionalAmout - availableToAdd;

		}

		public void Decrease(int extraAmount)
		{
			if (extraAmount > _amount)
				throw new ArgumentException("Extra amount can't be more than amount");

			_amount -= extraAmount;
		}

		public void PutAllTo(Cell other)
		{
			int putAmount = Mathf.Min(amount, other.freePlaces);
			PutTo(other, putAmount);
		}

		public void PutTo(Cell other, int putAmount)
		{
			if (putAmount > amount)
				throw new ArgumentException("Can't put out more than it contains");

			putAmount = Mathf.Min(putAmount, other.freePlaces);

			Decrease(putAmount);
			other.Increase(putAmount);
		}

		public static Cell Create(Resource resource, int maxCount = 1000)
		{
			Cell cell = new Cell();

			cell._resource = resource;
			cell._limit = maxCount;

			return cell;
		}
	}
}
