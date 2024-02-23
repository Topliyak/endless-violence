using UnityEngine;
using Inventory;

namespace CraftSystem.Menu
{
	public class CraftMenu : MonoBehaviour
	{
		[SerializeField] private StorageWithResources _storage;

		private ResourceInMenu[] _resourceViews;

		private void Awake()
		{
			_resourceViews = GetComponentsInChildren<ResourceInMenu>();
		}

		private void OnEnable()
		{
			_storage.setChanged += UpdateViews;

			UpdateViews();
		}

		private void OnDisable()
		{
			_storage.setChanged -= UpdateViews;
		}

		private void UpdateViews()
		{
			foreach (var view in _resourceViews)
			{
				Resource resource = view.resource;

				int count = _storage.CountOf(resource);
				int limit = _storage.LimitFor(resource);

				view.Set(limit, count);
			}
		}
	}
}
