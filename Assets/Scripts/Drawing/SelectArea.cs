using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drawing
{
    public class SelectArea : MonoBehaviour
    {
        private RectTransform rectTransform;
        public TextMeshProUGUI sizeText;
        
        public float size
        {
            get => rectTransform.sizeDelta.x;
        }

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
            var size = rectTransform.sizeDelta.x;

            switch (size)
            {
                case >= 2048 when scrollDeltaY > 0:
                case <= 32 when scrollDeltaY < 0:
                    return;
            }

            ResetSize(size + scrollDeltaY * 2);
        }

        public void ResetSize(float size = 96)
        {
            sizeText.text = $"{size}";
            rectTransform.sizeDelta = new Vector2(size, size);
        }
    }
}