using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Drawing
{
    public class Artboard : MonoBehaviour, IPointerClickHandler, IPointerMoveHandler, IBeginDragHandler, IDragHandler,
        IScrollHandler
    {
        public Canvas canvas;
        public SelectArea selectArea;
        public TaskArea taskTemplate;
        public Transform taskGroup;

        private bool spaceMode = false;

        /// <summary>
        /// Relative position of mouse in the canvas
        /// </summary>
        private Vector2 mousePosition = Vector2.zero;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            if (spaceMode)
            {
                EnterSpaceMode();
            }
            else
            {
                ExitSpaceMode();
            }
        }

        private void FixedUpdate()
        {
            var mouse = Mouse.current;
            var keyboard = Keyboard.current;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                this.transform as RectTransform,
                mouse.position.ReadValue(),
                canvas.worldCamera,
                out var realPos
            );

            mousePosition = realPos + new Vector2(1920, 1080) / 2;
            spaceMode = keyboard.spaceKey.isPressed;
        }

        private void EnterSpaceMode()
        {
            selectArea.gameObject.SetActive(false);
        }

        private void ExitSpaceMode()
        {
            selectArea.gameObject.SetActive(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateTaskArea();
        }

        private void CreateTaskArea()
        {
            var go = Instantiate(taskTemplate, taskGroup);
            go.MoveTo(mousePosition);
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
            selectArea.MoveTo(mousePosition);
        }

        public void OnScroll(PointerEventData eventData)
        {
            selectArea.Scale(eventData.scrollDelta.y);
        }
    }
}