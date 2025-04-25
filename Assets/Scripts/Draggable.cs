using UnityEngine;

public class Draggable : MonoBehaviour, IDraggable
{
    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private Item _parentItem;
    [SerializeField] BoxCollider _boxCollider;

    private Vector3 _targetPosition;
    private readonly float _smoothSpeed = 100f;

    private bool _isDragging;

    public void StartDragging(Vector3 interactionPoint)
    {
        _isDragging = true;
        _parentItem.SetKinematic();
        _targetPosition = transform.position;
    }

    public void StopDragging()
    {
        _isDragging = false;
        _parentItem.SetPhysic();
    }

    public void UpdateDrag(Vector3 desiredPosition)
    {
        if (_isDragging == false) 
            return;

        if (CanMoveTo(desiredPosition))
            _targetPosition = desiredPosition;        

        Vector3 smoothedPosition = Vector3.Lerp(
            _parentItem.transform.position,
            _targetPosition,
            _smoothSpeed * Time.deltaTime
        );

        _parentItem.transform.position = smoothedPosition;
    }

    private bool CanMoveTo(Vector3 position)
    {
        Vector3 moveDirection = position - transform.position;
        float distance = moveDirection.magnitude;

        return !Physics.BoxCast(
            transform.TransformPoint(_boxCollider.center),
            _boxCollider.size * 0.5f,
            moveDirection.normalized,
            transform.rotation,
            distance,
            _itemLayer
        );
    }
}

