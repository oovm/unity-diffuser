using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Drawing
{
    public class Artboard : MonoBehaviour, IPointerClickHandler, IPointerMoveHandler, IBeginDragHandler, IDragHandler, IScrollHandler
    {
        public Canvas canvas;
        public SelectArea selectArea;

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
            var mouse = Mouse.current;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                mouse.position.ReadValue(),
                canvas.worldCamera,
                out var pos
            );
            return pos;
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

        public void DisableSelectArea()
        {
            GetComponentInChildren<SelectArea>().gameObject.SetActive(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            selectArea.gameObject.SetActive(true);
            selectArea.MoveTo(GetMousePosition());
        }

        public void OnScroll(PointerEventData eventData)
        {
            selectArea.Scale(eventData.scrollDelta.y);
        }
    }
}