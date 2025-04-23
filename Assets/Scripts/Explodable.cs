using UnityEngine;

public class Explodable : MonoBehaviour, IExplodable
{
    [SerializeField] private Rigidbody _parentItemRigidBody;

    public void TakeExplosionEffect(Vector3 explosionPosition, float explosionStrength, float explosionRadius, float upwardModifier)
    {
        Vector3 forceDirection = explosionPosition - transform.position;
        float distanceToExplosion = forceDirection.magnitude;

        float explosionForce = CalculateForce(distanceToExplosion, explosionStrength, explosionRadius);

        _parentItemRigidBody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardModifier, ForceMode.Impulse);
    }

    private float CalculateForce(float distanceToExplosion, float explosionStrength, float explosionradius)    
    {
        float force = explosionStrength * (1 - distanceToExplosion/explosionradius);
        return force;
    }
}
