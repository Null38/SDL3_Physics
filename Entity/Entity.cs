using SDL3;
using System.Drawing;
using System.Numerics;

namespace SDL3_Physics.Entity;

public abstract class Entity
{
    public Vector2 Position;
    public Vector2 Size;

    protected float xRemainder;
    protected float yRemainder;

    public Color color;

    public void Render(nint renderer)
    {
        SDL.SetRenderDrawColor(renderer, color.R, color.G, color.B, color.A);

        SDL.FRect rect = new SDL.FRect
        {
            X = Position.X,
            Y = Position.Y,
            W = Size.X,
            H = Size.Y
        };

        SDL.RenderFillRect(renderer, rect);
    }

    public virtual void Update() {}

    protected bool collideAt(List<Entity> entities, Vector2 newPos)
    {
        foreach (var entity in entities)
        {
            if (newPos.X          < entity.Position.X + entity.Size.X &&
                newPos.X + Size.X > entity.Position.X &&
                newPos.Y          < entity.Position.Y + entity.Size.Y &&
                newPos.Y + Size.X > entity.Position.Y )
                return true;
        }

        return false;
    }
}
