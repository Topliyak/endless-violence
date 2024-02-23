using UnityEngine;

namespace MyInput
{
	public static class Input
	{
		public static KeyboardLayout keyboardLayout;

		public static bool sprinting => UnityEngine.Input.GetKey(keyboardLayout.sprintButton);

		public static bool jumped => UnityEngine.Input.GetKeyDown(keyboardLayout.jumpButton);

		public static bool crouched => UnityEngine.Input.GetKeyDown(keyboardLayout.crouchButton);

		public static bool next => UnityEngine.Input.GetKeyDown(keyboardLayout.next);

		public static bool previous => UnityEngine.Input.GetKeyDown(keyboardLayout.previous);

		public static bool fire => UnityEngine.Input.GetMouseButton(0);

		public static bool aim => UnityEngine.Input.GetMouseButton(1);

		public static Vector2 axis => GetInputAxis();

		private static Vector2 GetInputAxis()
		{
			float horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
			float vertical = UnityEngine.Input.GetAxisRaw("Vertical");

			return new Vector2(horizontal, vertical);
		}
	}
}

