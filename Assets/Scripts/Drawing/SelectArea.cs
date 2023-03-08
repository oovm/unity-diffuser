using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drawing
{
    public class SelectArea : MonoBehaviour
    {
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            ResetSize();
        }

        public void MoveTo(Vector2 position)
        {
            transform.position = position;
        }

        public void Scale(float scrollDeltaY)
        {
            var size = rectTransform.sizeDelta;

            switch (size.x)
            {
                case >= 2048 when scrollDeltaY > 0:
                case <= 32 when scrollDeltaY < 0:
                    return;
            }

            size.x += scrollDeltaY * 8;
            size.y += scrollDeltaY * 8;
            rectTransform.sizeDelta = size;
        }

        public void ResetSize()
        {
            rectTransform.sizeDelta = new Vector2(96, 96);
        }
    }
}