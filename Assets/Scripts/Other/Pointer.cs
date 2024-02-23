using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Other
{
	public class Pointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
						   IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public event UnityAction<GameObject> onPointerDown;
		public event UnityAction<GameObject> onPointerUp;
		public event UnityAction<GameObject> onPointerEnter;
		public event UnityAction<GameObject> onPointerExit;
		public event UnityAction<GameObject> onPointerClick;

		public void OnPointerClick(PointerEventData eventData) => onPointerClick?.Invoke(gameObject);

		public void OnPointerDown(PointerEventData eventData) => onPointerDown?.Invoke(gameObject);

		public void OnPointerUp(PointerEventData eventData) => onPointerUp?.Invoke(gameObject);

		public void OnPointerEnter(PointerEventData eventData) => onPointerEnter?.Invoke(gameObject);

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => onPointerExit?.Invoke(gameObject);
	}
}
