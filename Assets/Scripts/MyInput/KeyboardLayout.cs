using UnityEngine;

namespace MyInput
{
	[CreateAssetMenu(menuName = "ScriptableObjects/KeyboardLayout")]
	public class KeyboardLayout : ScriptableObject
	{
		public KeyCode sprintButton;
		public KeyCode jumpButton;
		public KeyCode crouchButton;
		public KeyCode next;
		public KeyCode previous;
		public KeyCode aim;
	}
}
