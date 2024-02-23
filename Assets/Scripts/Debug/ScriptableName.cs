using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDebug
{
	public class ScriptableName : MonoBehaviour
	{
		public Object obj;

		private void Start()
		{
			print(obj.name);
		}
	}
}
