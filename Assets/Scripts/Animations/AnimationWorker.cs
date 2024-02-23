using UnityEngine;

namespace Animations
{
	[RequireComponent(typeof(Animator))]
	public abstract class AnimationWorker : MonoBehaviour
	{
		private Animator _animator;

		public Animator animator
		{
			get
			{
				if (_animator == null)
					throw new MyExceptions.BaseInitializerWasntCalledException();

				return _animator;
			}
			set => _animator = value;
		}

		protected virtual void Awake()
		{
			animator = GetComponent<Animator>();
		}

		public void Enable()
		{
			enabled = true;
		}

		public void Disable()
		{
			enabled = false;
		}
	}
}
