using System.Collections;
using UnityEngine;

namespace Input
{
    public class Scroll : MonoBehaviour
    {
        [SerializeField] private bool isAndroid;
        private bool waiting;

        public Vector2 ScrollValue { get; private set; }
        public Vector2 StartPosition { get; private set; }

        private void FixedUpdate()
        {
            if (isAndroid)
            {
                if (!waiting && UnityEngine.Input.touchCount > 0) StartCoroutine(OnDragging());
            }
            else
            {
                if (!waiting && UnityEngine.Input.GetMouseButton(0)) StartCoroutine(OnDragging());
            }
        }

        private IEnumerator OnDragging(float waitTime = 0.10f)
        {
            if (isAndroid)
            {
                var startTouchPosition = UnityEngine.Input.touches[0].position;
                waiting = true;
                yield return new WaitForSecondsRealtime(waitTime);
                waiting = false;
                ScrollValue = UnityEngine.Input.touchCount > 0 ? UnityEngine.Input.touches[0].position - startTouchPosition : Vector2.zero;
                StartPosition = startTouchPosition;
            }
            else
            {
                var startTouchPosition = new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y);
                waiting = true;
                yield return new WaitForSecondsRealtime(waitTime);
                waiting = false;
                ScrollValue = UnityEngine.Input.GetMouseButton(0)
                    ? new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y) - startTouchPosition
                    : Vector2.zero;
                StartPosition = startTouchPosition;
            }
        }
    }
}