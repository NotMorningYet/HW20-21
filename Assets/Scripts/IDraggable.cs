using UnityEngine;

public interface IDraggable
{ 
    public void StartDragging(Vector3 interactionPoint);
    public void UpdateDrag(Vector3 currentMouseWorldPos);
    public void StopDragging();
}
