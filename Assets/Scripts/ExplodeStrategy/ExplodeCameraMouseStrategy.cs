using UnityEngine;

public class ExplodeCameraMouseStrategy : IExplodeStrategy
{
    public bool CanPlaceExplosion(LayerMask canPlaceExplosionMask, out Vector3 position)
    {
        bool canPlace = false;
        position = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, canPlaceExplosionMask))
        {
            canPlace = true;
            position = hit.point;
        }

        return canPlace;
    }
}
