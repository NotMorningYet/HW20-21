using UnityEngine;

public class ExplosionFactory : MonoBehaviour
{
    [SerializeField] Explosion _explosionPrefab;

    public Explosion Get(Vector3 position)
    {
        Explosion explosion = Instantiate(_explosionPrefab, position, Quaternion.identity);

        return explosion; 
    }
}
