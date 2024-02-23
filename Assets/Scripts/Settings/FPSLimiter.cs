using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
	public class FPSLimiter : MonoBehaviour
	{
		[SerializeField]
		private int _targetFPS;

		private void OnValidate()
		{
			Application.targetFrameRate = _targetFPS;
		}
	}
}
