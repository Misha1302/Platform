using System.Collections;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private bool isAndroid;
    private bool _waiting;

    public Vector2 ScrollValue { get; private set; }

    private void Update()
    {
        if (isAndroid)
        {
            if (!_waiting && Input.touchCount > 0) StartCoroutine(OnDragging());
        }
        else
        {
            if (!_waiting && Input.GetMouseButton(0)) StartCoroutine(OnDragging());
        }
    }

    private IEnumerator OnDragging(float waitTime = 0.1f)
    {
        if (isAndroid)
        {
            var startTouchPosition = Input.touches[0].position;
            _waiting = true;
            yield return new WaitForSecondsRealtime(waitTime);
            _waiting = false;
            ScrollValue = Input.touchCount > 0 ? Input.touches[0].position - startTouchPosition : Vector2.zero;
        }
        else
        {
            var startTouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _waiting = true;
            yield return new WaitForSecondsRealtime(waitTime);
            _waiting = false;
            ScrollValue = Input.GetMouseButton(0)
                ? new Vector2(Input.mousePosition.x, Input.mousePosition.y) - startTouchPosition
                : Vector2.zero;
        }

        ScrollValue *= Time.deltaTime;
    }
}