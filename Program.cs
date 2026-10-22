using SDL3;
using SDL3_Physics.Core;
using SDL3_Physics.Entity;
using Color = System.Drawing.Color;

namespace App;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Player player = new Player
        {
            color = Color.White
        };

        using var window = new Window();
        Game.Initialize(window);

        Game.entities.Add(player);
        Game.AddSoild(
            new Solid
            {
                color = Color.Red,
                Position = new(0, 500),
                Size = new(500, 50)
            });
        Game.AddSoild(
            new Solid
            {
                color = Color.Red,
                Position = new(300, 250),
                Size = new(50, 200)
            });

        window.Run();
    }
}