using UnityEngine;
using Inventory;

namespace Hero
{
	[RequireComponent(typeof(StorageWithResources))]
	public class Collector : MonoBehaviour
	{
		private StorageWithResources _inventory;

		private void Awake()
		{
			_inventory = GetComponent<StorageWithResources>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag != Tags.oneTimeStorage)
				return;

			var storage = other.GetComponent<StorageWithResources>();
			_inventory.UnionWith(storage);

			Destroy(other.gameObject);
		}
	}
}
