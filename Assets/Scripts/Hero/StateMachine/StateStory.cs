using UnityEngine;
using System;

namespace Hero
{
	[RequireComponent(typeof(StateSwitcher))]
	public class StateStory : MonoBehaviour
	{
		[SerializeField] private int _length;

		private State[] _states;
		private int _lastIndex = -1;
		private StateSwitcher _stateSwitcher;

		public int RecordsCount { get; private set; } = 0;

		public bool HasRecords => RecordsCount > 0;

		public State this[int index]
		{
			get
			{
				int lngth = Mathf.Min(_length, RecordsCount);

				if (index < -lngth || index >= lngth)
					throw new IndexOutOfRangeException();
				
				index += 1;
				index = (_lastIndex + index) % _length;
				index = (index + _length) % _length;

				return _states[index];
			}
		}

		private void Awake()
		{
			_states = new State[_length];
			_stateSwitcher = GetComponent<StateSwitcher>();
		}

		private void OnEnable()
		{
			_stateSwitcher.stateChanged += Record;
		}

		private void OnDisable()
		{
			_stateSwitcher.stateChanged -= Record;
		}

		public void Record()
		{
			_lastIndex = (_lastIndex + 1) % _length;
			_states[_lastIndex] = _stateSwitcher.Current;

			RecordsCount++;
		}

		private void OnValidate()
		{
			if (_length <= 0)
				throw new UnassignedReferenceException("Length of state story must be positive");
		}
	}
}
