namespace Hero.Weaponed.WithPistol
{
	public class OnFootAimAnimator_Pistol : MovingStateAnimator
	{
		public override string stateParametr => AnimatorParameters.onFoot;

		protected override void OnEnable()
		{
			base.OnEnable();
			animator.SetLayerWeight(layerIndex: 2, weight: 1);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			animator.SetLayerWeight(layerIndex: 2, weight: 0);
		}
	}
}
