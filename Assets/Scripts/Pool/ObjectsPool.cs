using UnityEngine;

namespace Pool
{
	public class ObjectsPool<T> : MonoBehaviour where T : Component
	{
		[SerializeField] private int _size;
		[SerializeField] private T _template;
		[SerializeField] private Transform _objectsInPullParent;

		private T[] _objects;
		private int _lastFilledIndex;

		protected virtual void Awake()
		{
			_objects = new T[_size];
			_lastFilledIndex = -1;

			for (int i = 0; i < _size; i++)
				Put(Instantiate(_template));
		}

		public T Get()
		{
			if (_lastFilledIndex == -1)
				return Instantiate(_template);

			return _objects[_lastFilledIndex--];
		}

		public void Put(T obj)
		{
			int freeIndex = _lastFilledIndex + 1;

			if (freeIndex == _size)
				Destroy(obj.gameObject);

			obj.transform.parent = _objectsInPullParent;
			obj.gameObject.SetActive(false);

			_objects[freeIndex] = obj;
			_lastFilledIndex++;
		}
	}
}
