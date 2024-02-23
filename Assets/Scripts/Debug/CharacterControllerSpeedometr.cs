using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDebug
{
	public class CharacterControllerSpeedometr : MonoBehaviour
	{
		private float prevSpeed = 0;
		private CharacterController _chC;

		public float minSpeed = 0;
		
		private void Awake()
		{
			_chC = GetComponent<CharacterController>();
		}

		private void FixedUpdate()
		{
			if (_chC.velocity.y < minSpeed)
				minSpeed = _chC.velocity.y;

			print(_chC.velocity.y);
		}
	}
}
