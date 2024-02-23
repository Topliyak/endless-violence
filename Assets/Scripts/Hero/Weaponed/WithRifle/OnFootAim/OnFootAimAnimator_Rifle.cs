using UnityEngine;
using Weapons;

namespace Hero.Weaponed.WithRifle
{
	public class OnFootAimAnimator_Rifle: MovingStateAnimator
	{
		public override string stateParametr => AnimatorParameters.onFoot;

		protected override void OnEnable()
		{
			base.OnEnable();
			animator.SetLayerWeight(layerIndex: 1, weight: 1);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			animator.SetLayerWeight(layerIndex: 1, weight: 0);
		}
	}
}
