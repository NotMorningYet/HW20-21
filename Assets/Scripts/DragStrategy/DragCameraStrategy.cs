using UnityEngine;

public class DragCameraStrategy : IDragStrategy
{
    private Plane _dragPlane;
    private Vector3 _lastTargetWorldPos;

    public void InitializateDragStrategy(RaycastHit hit)
    {
        _dragPlane = new Plane(Vector3.up, hit.point);
        _lastTargetWorldPos = GetTargetWorldPosition();
    }

    public Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public void StopDrag()
    {
       
    }

    public Vector3 GetTargetWorldPosition()
    {
        Ray ray = GetRay();

        if (_dragPlane.Raycast(ray, out float enter))
            return ray.GetPoint(enter);

        return _lastTargetWorldPos;
    }
}
