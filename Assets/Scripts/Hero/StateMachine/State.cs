using UnityEngine;
using UnityEngine.Events;

namespace Hero
{
	public abstract class State : MonoBehaviour
	{
		protected StateSwitcher stateSwitcher { get; private set; }

		public void Init(StateSwitcher switcher, bool enabled)
		{
			stateSwitcher = switcher;

			if (enabled)
				Enable();
			else
				this.enabled = enabled;
		}

		public void Enable()
		{
			enabled = true;
		}

		public void TransitTo<T>() where T: State
		{
			stateSwitcher.TransitTo<T>();
		}
	}
}
