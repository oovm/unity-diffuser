using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drawing
{
    public class TaskArea : MonoBehaviour
    {
        private RectTransform rectTransform;
        public TextMeshProUGUI sizeText;

        /// <summary>
        /// <span style="color: #5050FF;">InprogressColor</span>
        /// </summary>
        private Color InprogressColor = new(0.5f, 0.5f, 1f, 1f);

        /// <summary>
        /// <span style="color: #50FF50;">ReadyColor</span>
        /// </summary>
        private Color ReadyColor = new(0.5f, 1f, 0.5f, 1f);


        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            ResetSize();
        }

        public void MoveTo(Vector2 position)
        {
            transform.position = position;
        }

        public void ChangeColor(Color color)
        {
            sizeText.color = color;
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