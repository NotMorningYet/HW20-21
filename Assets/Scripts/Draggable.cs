using UnityEngine;

public class Draggable : MonoBehaviour, IDraggable
{
    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private Item _parentItem;
    [SerializeField] private float _collisionCheckRadius = 0.5f;
    [SerializeField] BoxCollider _boxCollider;

    private Vector3 _dragOffset;
    private Vector3 _targetPosition;
    private readonly float _smoothSpeed = 100f;
    private float _initialYPosition;

    public bool _isDragging;

    public void StartDragging(Vector3 interactionPoint)
    {
        _isDragging = true;
        _initialYPosition = _parentItem.transform.position.y;
        
        Vector3 interactionPointXZ = new Vector3(interactionPoint.x, _initialYPosition, interactionPoint.z);

        _dragOffset = _parentItem.transform.position - interactionPointXZ;
        _targetPosition = _parentItem.transform.position;
    }

    public void StopDragging()
    {
        _isDragging = false;
    }

    public void UpdateDrag(Vector3 currentMouseWorldPos)
    {
        if (_isDragging == false) 
            return;

        Vector3 desiredPosition = currentMouseWorldPos + _dragOffset;

        if (CanMoveTo(desiredPosition))
        {
            _targetPosition = desiredPosition;
        }

        Vector3 smoothedPosition = Vector3.Lerp(
            _parentItem.transform.position,
            new Vector3(_targetPosition.x, _initialYPosition, _targetPosition.z),
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

