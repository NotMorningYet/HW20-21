using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField] private Texture2D _defaultCursor;
    [SerializeField] private Texture2D _dragCursor;

    private void Awake()
    {
       SetDefaultCursor();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            IDraggable dragable = hit.collider.GetComponent<IDraggable>();

            if (dragable != null)
            {
                SetDragCursor();
            }
            else
                SetDefaultCursor();
        }
    }

    private void SetDefaultCursor()
    {
        Cursor.SetCursor(_defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    private void SetDragCursor()
    {
        Cursor.SetCursor(_dragCursor, Vector2.zero, CursorMode.Auto);
    }
}
