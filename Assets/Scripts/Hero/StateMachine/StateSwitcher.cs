using UnityEngine;
using UnityEngine.Events;

namespace Hero
{
	public class StateSwitcher : MonoBehaviour
	{
		[SerializeField] private State _entryState;

		public event UnityAction stateChanged;

		public State Current { get; private set; }

		private void Start()
		{
			foreach (var state in GetComponents<State>())
				state.Init(switcher: this, enabled: false);

			Launch(_entryState);
		}

		public void TransitTo<T>() where T: State
		{
			State state = GetComponent<T>();

			if (state == null)
				throw new System.ArgumentNullException("State cant't be null");

			Current.enabled = false;
			Launch(state);
		}

		public void TransitTo(State state)
		{
			if (state == null)
				throw new System.ArgumentNullException("State cant't be null");

			Current.enabled = false;
			Launch(state);
		}

		private void Launch(State state)
		{
			Current = state;
			Current.Enable();

			stateChanged?.Invoke();
		}
	}
}
