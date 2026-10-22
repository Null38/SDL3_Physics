using SysMath = System.Math;

namespace SDL3_Physics.Core;

public static class Math
{
    public static int Round(float value)
    {
        return (int)SysMath.Round(value);
    }

    public static int Sign(int value)
    {
        return SysMath.Sign(value);
    }

    public static float Approach(float current, float target, float MaxDelta)
    {
        float delta = target - current;

        if (SysMath.Abs(delta) <= MaxDelta)
            return target;

        return current + (delta > .0f ? MaxDelta : -MaxDelta);
    }
}
