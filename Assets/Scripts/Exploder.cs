using UnityEngine;

public class Exploder :MonoBehaviour
{
    [SerializeField] private Explosion _explosionPrefab;
    [SerializeField] private int _strength;
    [SerializeField] private int _radius;
    [SerializeField] private float _upwardModifier;
    [SerializeField] private LayerMask _canPlaceExplosionMask;
    
    private Vector3 _position;

    public void CreateExplosion()
    {        
        if (CanCreateExplosion(out _position))
        {
            Explosion explosion = Instantiate(_explosionPrefab, _position, Quaternion.identity);
            explosion.Initialize(_position, _strength, _radius, _upwardModifier);
            explosion.MakeBoom();
        }        
    }
    
    private bool CanCreateExplosion(out Vector3 position)
    {
        bool canPlace = false;
        position = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _canPlaceExplosionMask))
        {
            CanPlaceExplodable surface = hit.collider.GetComponent<CanPlaceExplodable>();

            if (surface != null)
            {
                canPlace = true;
                position = hit.point;
            }         
        }        

        return canPlace;
    }

}
