using UnityEngine;
using UnityEngine.EventSystems;

namespace Drawing
{
    public class Artboard : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler
    {
        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private Vector2 GetMousePosition()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(GetMousePosition());
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Debug.Log(GetMousePosition());
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Debug.Log(GetMousePosition());
        }
    }
}