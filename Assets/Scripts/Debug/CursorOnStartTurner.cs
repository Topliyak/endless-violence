using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyDebug
{
	public class CursorOnStartTurner : MonoBehaviour
	{
		public bool turnedOnStart;

		private Settings.CursorTurner _cursorTurner;

		private void Awake()
		{
			_cursorTurner = FindObjectOfType<Settings.CursorTurner>();
		}

		private void Start()
		{
			if (turnedOnStart)
				_cursorTurner.Show();
			else
				_cursorTurner.Hide();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.P))
				_cursorTurner.Show();
		}
	}
}
