using UnityEngine;

public class Dragger
{
    private IDraggable _currentDraggable;
    private Vector3 _lastMouseWorldPos;
    private Plane _dragPlane;
    private readonly string _draggableMask = "Draggable";


    public void StartDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask(_draggableMask)))
        {
            _currentDraggable = hit.collider.GetComponent<IDraggable>();

            if (_currentDraggable != null)
            {
                _dragPlane = new Plane(Vector3.up, hit.point);
                _lastMouseWorldPos = GetMouseWorldPositionOnPlane();
                _currentDraggable.StartDragging(_lastMouseWorldPos);
            }
        }  
    }

    public void UpdateDrag()
    {
        if (_currentDraggable == null) 
            return;

        Vector3 currentMouseWorldPos = GetMouseWorldPositionOnPlane();
        _currentDraggable.UpdateDrag(currentMouseWorldPos);
        _lastMouseWorldPos = currentMouseWorldPos;
    }

    public void StopDrag()
    {
        if (_currentDraggable != null)
        {
            _currentDraggable.StopDragging();
            _currentDraggable = null;
        }
    }

    private Vector3 GetMouseWorldPositionOnPlane()
    {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (_dragPlane.Raycast(ray, out float enter))
            return ray.GetPoint(enter);       

        return _lastMouseWorldPos;
    }
}
