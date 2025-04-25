using UnityEngine;

public interface IDragStrategy
{
    public void InitializateDragStrategy(RaycastHit hit);
    public Ray GetRay();
    public Vector3 GetTargetWorldPosition();
    public void StopDrag();
}
