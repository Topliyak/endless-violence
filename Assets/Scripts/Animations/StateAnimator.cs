namespace Animations
{
	public abstract class StateAnimator : AnimationWorker
	{
		public abstract string stateParametr { get; }

		protected void TurnOnState()
		{
			animator.SetBool(stateParametr, true);
		}

		protected void TurnOffState()
		{
			animator.SetBool(stateParametr, false);
		}

		protected virtual void OnEnable() => TurnOnState();

		protected virtual void OnDisable() => TurnOffState();
	}
}
