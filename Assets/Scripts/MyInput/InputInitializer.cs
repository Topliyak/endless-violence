namespace MyInput
{
    public class InputInitializer : UnityEngine.MonoBehaviour
    {
        public KeyboardLayout keyboardLayout;

		private void Awake()
		{
			if (keyboardLayout == null)
				throw new UnityEngine.UnassignedReferenceException("Keyboard Layout not defined");

			Input.keyboardLayout = keyboardLayout;
		}
	}
}
