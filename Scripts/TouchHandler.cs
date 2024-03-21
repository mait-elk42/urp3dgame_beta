using UnityEngine.EventSystems;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    Vector2 scrollPosition;
    Touch touch;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                scrollPosition.y += touch.deltaPosition.y;
                scrollPosition.x += touch.deltaPosition.y;
            }
        }
        Debug.ClearDeveloperConsole();
        Debug.Log(scrollPosition);
        scrollPosition = Vector2.zero;
    }
}
