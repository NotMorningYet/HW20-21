using UnityEngine;

public interface IExplodeStrategy 
{
    public bool CanPlaceExplosion(LayerMask canPlaceExplosionMask, out Vector3 position);
}
