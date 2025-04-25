using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ExplosionFactory _explosionFactory;

    private Dragger _dragger;
    private Exploder _exploder;

    private bool _isDragging;
    private readonly int _leftMouseButton = 0;
    private readonly int _rightMouseButton = 1;

    private void Awake()
    {
        _dragger = new Dragger();
        _exploder = new Exploder(_explosionFactory);
        _isDragging = false;
    }

    private void Update()
    {
        HandleDragInput();
        HandleExplodeInput();
    }

    private void HandleExplodeInput()
    {
        if (Input.GetMouseButtonDown(_rightMouseButton))
            _exploder.CreateExplosion();
    }

    private void HandleDragInput()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            _isDragging = true;
            _dragger.StartDrag();
        }

        if (_isDragging)
        {
            _dragger.UpdateDrag();

            if (Input.GetMouseButtonUp(_leftMouseButton))
            {
                _isDragging = false;
                _dragger.StopDrag();
            }
        }
    }
}
