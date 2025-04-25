using System;

public class DragStrategySwitcher
{
    public IDragStrategy SetStrategy(DragStrategyTypes dragStrategyType)
    {
        switch (dragStrategyType)
        {
            case DragStrategyTypes.Camera:
                return new DragCameraStrategy();
            default:
                throw new ArgumentException(nameof(dragStrategyType));
        }
    }
}
