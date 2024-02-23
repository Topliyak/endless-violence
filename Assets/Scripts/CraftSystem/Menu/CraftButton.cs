using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CraftSystem.Menu
{
	public class CraftButton : MonoBehaviour
	{
		[SerializeField] private Button _button;

		public event UnityAction<GameObject> onPointerDown;
		public event UnityAction<GameObject> onPointerUp;

		private void OnEnable()
		{

		}

		private void OnPointerDown() => onPointerDown?.Invoke(gameObject);

		private void OnPointerUp() => onPointerUp?.Invoke(gameObject);
	}
}
