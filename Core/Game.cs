using SDL3;

namespace SDL3_Physics.Core;

static class Game
{
    public static Window Window { get; private set; } = null!;


    readonly public static HashSet<SDL.Keycode> keyInput = new();

    readonly public static List<Entity.Entity> entities = new();
    readonly public static List<Entity.Entity> solids = new();


    public static void Initialize(Window window)
    {
        Window = window;

        Window.Update += Update;
        Window.Render += Render;
    }

    private static void Update()
    {
        foreach (var item in entities)
        {
            item.Update();
        }
    }


    private static void Render()
    {
        foreach (var item in entities)
        {
            item.Render(Window.renderer);
        }
    }

    public static void AddSoild(Entity.Entity entity)
    {
        entities.Add(entity);
        solids.Add(entity);
    }
}
