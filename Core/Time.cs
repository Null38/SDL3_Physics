using SDL3;
using System;

namespace SDL3_Physics.Core;

static class Time
{
    private static ulong currentFrameTime;
    private static ulong lastFrameTime;


    public static void SetCurrentFrameTime(ulong time)
    {
        lastFrameTime = currentFrameTime;
        currentFrameTime = time;
    }

    public static float Deltatime 
    {
        get
        {
            return (currentFrameTime - lastFrameTime) / (float)SDL.GetPerformanceFrequency();
        }
    }
}
