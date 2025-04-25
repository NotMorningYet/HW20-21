using UnityEngine;

public class Dragger
{
    private IDraggable _currentDraggable;
    private IDragStrategy _dragStrategy;
    private DragStrategySwitcher _dragStrategySwitcher;
    private Vector3 _targetWorldPosition;
    private Vector3 _dragOffset;
    private readonly string _draggableMask = "Draggable";

    public Dragger()
    {
        _dragStrategySwitcher = new DragStrategySwitcher();
        _dragStrategy = _dragStrategySwitcher.SetStrategy(DragStrategyTypes.Camera);
    }

    public void StartDrag()
    {
        Ray ray = _dragStrategy.GetRay();

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask(_draggableMask)))
        {
            _currentDraggable = hit.collider.GetComponent<IDraggable>();

            if (_currentDraggable != null)
            {
                _dragStrategy.InitializateDragStrategy(hit);
                _targetWorldPosition = _dragStrategy.GetTargetWorldPosition();
                _dragOffset = hit.transform.position - _targetWorldPosition;
                _currentDraggable.StartDragging(_targetWorldPosition);
            }
        }  
    }

    public void UpdateDrag()
    {
        if (_currentDraggable == null) 
            return;

        _targetWorldPosition = _dragStrategy.GetTargetWorldPosition();
        _currentDraggable.UpdateDrag(_targetWorldPosition + _dragOffset);
    }

    public void StopDrag()
    {
        if (_currentDraggable != null)
        {
            _currentDraggable.StopDragging();
            _currentDraggable = null;
        }
    }
}
