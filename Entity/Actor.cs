using SDL3;
using SDL3_Physics.Core;
using System.Diagnostics;
using System.Numerics;
using Math = SDL3_Physics.Core.Math;

namespace SDL3_Physics.Entity
{
    abstract class Actor : Entity
    {
        public void MoveX(float amount, Action onCollide)
        {
            xRemainder += amount;
            int move = Math.Round(xRemainder);
            
            if (move == 0)
                return;

            xRemainder -= move;
            int sign = Math.Sign(move);

            while (move != 0)
            {
                if (!collideAt(Game.solids, Position + new Vector2(sign, 0)))
                {
                    //There is no Solid immediately beside us 
                    Position.X += sign;
                    move -= sign;
                }
                else
                {
                    //Hit a solids!
                    if (onCollide != null)
                        onCollide();
                    break;
                }
            }
        }
        public void MoveY(float amount, Action onCollide)
        {
            yRemainder += amount;
            int move = Math.Round(yRemainder);

            if (move == 0)
                return;

            yRemainder -= move;
            int sign = Math.Sign(move);

            while (move != 0)
            {
                if (!collideAt(Game.solids, Position + new Vector2(0, sign)))
                {
                    //There is no Solid immediately beside us 
                    Position.Y += sign;
                    move -= sign;
                }
                else
                {
                    //Hit a solids!
                    if (onCollide != null)
                        onCollide();
                    break;
                }
            }
        }


        public virtual bool IsRiding(Solid solid)
        {
            throw new NotImplementedException();
        }

        public virtual void Squish()
        {
            throw new NotImplementedException();
        }
    }
}
