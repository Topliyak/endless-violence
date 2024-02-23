using UnityEngine;

namespace Hero.Weaponed
{
	[RequireComponent(typeof(StateStory))]
	[RequireComponent(typeof(StateSwitcher))]
	public class StateReturnerAfterFalling : MonoBehaviour
	{
		private StateSwitcher _stateSwitcher;
		private State _state;

		private void Awake()
		{
			_stateSwitcher = GetComponent<StateSwitcher>();
		}

		private void ReturnToState()
		{
			if (_stateSwitcher.Current is Falling == false)
			{
				_stateSwitcher.stateChanged -= ReturnToState;
				_stateSwitcher.TransitTo(_state);
			}
		}

		public void RecordStateForReturn(State state)
		{
			_state = state;
			_stateSwitcher.stateChanged += ReturnToState;
		}

		private void OnDisable()
		{
			_stateSwitcher.stateChanged -= ReturnToState;
		}
	}
}
