using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
	public class CursorTurner : MonoBehaviour
	{
		[ContextMenu("Show")]
		public void Show()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		[ContextMenu("Hide")]
		public void Hide()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
