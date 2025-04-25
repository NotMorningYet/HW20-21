using System;

public class ExplodeStrategySwitcher
{
    public IExplodeStrategy SetStrategy(ExplodeStrategyTypes explodeStrategyType)
    {
        switch (explodeStrategyType)
        {
            case ExplodeStrategyTypes.CameraMouse:
                return new ExplodeCameraMouseStrategy();
            default:
                throw new ArgumentException(nameof(explodeStrategyType));
        }
    }
}
