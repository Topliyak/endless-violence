using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
	public class StorageWithResources : MonoBehaviour
	{
		[SerializeField] private List<Cell> _items;

		public event UnityAction setChanged;

		public void Add(Cell otherCell)
		{
			Cell myCell = GetCellFor(otherCell.resource);
			otherCell.PutAllTo(myCell);

			setChanged?.Invoke();
		}

		public void Add(CraftSystem.Resource resource, int amount)
		{
			Cell myCell = GetCellFor(resource);
			myCell.TryIncreaseAndReturnExtra(amount);

			setChanged?.Invoke();
		}

		public void Remove(CraftSystem.Resource resource, int amount)
		{
			var item = GetCellFor(resource);

			if (item == null)
				throw new System.ArgumentException($"Can't remove {name}, it's not in storage");

			item.Decrease(amount);

			setChanged?.Invoke();
		}

		public int CountOf(CraftSystem.Resource resource)
		{
			Cell cell = GetCellFor(resource);
			return cell.amount;
		}

		public int LimitFor(CraftSystem.Resource resource)
		{
			Cell cell = GetCellFor(resource);
			return cell.limit;
		}

		public Cell GetCellFor(CraftSystem.Resource resource)
		{
			Cell cell = _items.FirstOrDefault(c => c.resource == resource);

			if (cell == null)
				cell = Cell.Create(resource);

			return cell;
		}

		public int PlacesFor(CraftSystem.Resource resource)
		{
			Cell cell = GetCellFor(resource);
			return cell.freePlaces;
		}

		public void UnionWith(StorageWithResources other)
		{
			foreach (var item in other._items)
				Add(item);
		}
	}
}
