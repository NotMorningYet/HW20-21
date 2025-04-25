using UnityEngine;

public class Exploder
{
    private int _strength = 8;
    private int _radius = 10;
    private float _upwardModifier = 2;
    private readonly ExplosionFactory _explosionFactory;
    private readonly string _canPlaceExplosionMask = "CanPlaceExplosion";
    private IExplodeStrategy _explodeStrategy;
    private ExplodeStrategySwitcher _explodeStrategySwitcher;

    private Vector3 _position;

    public Exploder(ExplosionFactory explosionFactory)
    {
        _explosionFactory = explosionFactory;
        _explodeStrategySwitcher = new ExplodeStrategySwitcher();
        _explodeStrategy = _explodeStrategySwitcher.SetStrategy(ExplodeStrategyTypes.CameraMouse);
    }

    public void CreateExplosion()
    {
        if (_explodeStrategy.CanPlaceExplosion(LayerMask.GetMask(_canPlaceExplosionMask), out _position))
        {
            Explosion explosion = _explosionFactory.Get(_position);
            explosion.Initialize(_position, _strength, _radius, _upwardModifier);
            explosion.MakeBoom();
        }
    }
}
