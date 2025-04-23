using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private LayerMask _explodableMask;

    private IExplodable _currentExplodable;
    private int _strength;
    private float _radius;
    private float _upwardModifier;
    private Vector3 _position;
    private float _lifeTime = 1;

    public void Initialize(Vector3 position, int strength, float radius, float upwardModifier)
    {
        _strength = strength;
        _position = position;
        _radius = radius;
        _upwardModifier = upwardModifier;
    }

    public void MakeBoom()
    {
        _explosionEffect.Play();

        Collider[] colliders = Physics.OverlapSphere(_position, _radius, _explodableMask);
        
        foreach (Collider hit in colliders) 
        {           
            _currentExplodable = hit.GetComponent<IExplodable>();
            _currentExplodable?.TakeExplosionEffect(_position, _strength, _radius, _upwardModifier);            
        }

        Destroy(gameObject, _lifeTime);
    }
}
