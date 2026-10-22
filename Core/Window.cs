using SDL3;
using System.Diagnostics;

namespace SDL3_Physics.Core;

public class Window : IDisposable
{
    public nint window { get; init; }
    public nint renderer { get; init; }

    public event Action? Update;
    public event Action? Render;

    public Window()
    {
        if (!SDL.Init(SDL.InitFlags.Video))
        {
            SDL.LogError(SDL.LogCategory.System, $"SDL could not initialize: {SDL.GetError()}");
            return;
        }

        if (!SDL.CreateWindowAndRenderer("Celeste Pysics study", 1280, 720, 0, out var window, out var renderer))
        {
            SDL.LogError(SDL.LogCategory.Application, $"Error creating window and rendering: {SDL.GetError()}");
            return;
        }

        this.window = window;
        this.renderer = renderer;

    }

    public void Run()
    {
        bool loop = true;

        while (loop)
        {
            while (SDL.PollEvent(out var e))
            {
                switch (e.Type)
                {
                    case (uint)SDL.EventType.KeyDown:
                        Game.keyInput.Add(e.Key.Key);
                        break;
                    case (uint)SDL.EventType.KeyUp:
                        Game.keyInput.Remove(e.Key.Key);
                        break;
                    case (uint)SDL.EventType.Quit:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }


            Time.SetCurrentFrameTime(SDL.GetPerformanceCounter());

            Update?.Invoke();

            SDL.SetRenderDrawColor(renderer, 0, 0, 0, 255);
            SDL.RenderClear(renderer);
            Render?.Invoke();
            SDL.RenderPresent(renderer);
        }
    }

    public void Dispose()
    {
        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);

        SDL.Quit();
    }
}
