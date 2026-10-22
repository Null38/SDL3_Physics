using Math = SDL3_Physics.Core.Math;

namespace SDL3_Physics.Entity;

class Solid : Entity
{

    public void Move(float x, float y)
    {
        xRemainder += x;
        yRemainder += y;
        int moveX = Math.Round(xRemainder);
        int moveY = Math.Round(yRemainder);

        if (moveX == 0 && moveY == 0)
            return;
/*
        //Loop through every Actor in the Level, add it to 
        //a list if actor.IsRiding(this) is true 
        List riding = GetAllRidingActors();
        //Make this Solid non-collidable for Actors, 
        //so that Actors moved by it do not get stuck on it 
        Collidable = false;
        if (moveX != 0)
        {
            xRemainder -= moveX;
            Position.X += moveX;
            if (moveX > 0)
            {
                foreach (Actor actor in Level.AllActors)
                {
                    if (overlapCheck(actor))
                    {
                        //Push right 
                        actor.MoveX(this.Right — actor.Left, actor.Squish);
                    }
                    else if (riding.Contains(actor))
                    {
                        //Carry right 
                        actor.MoveX(moveX, null);
                    }
                }
            }
            else
            {
                foreach (Actor actor in Level.AllActors)
                {
                    if (overlapCheck(actor))
                    {
                        //Push left 
                        actor.MoveX(this.Left — actor.Right, actor.Squish);
                    }
                    else if (riding.Contains(actor))
                    {
                        //Carry left 
                        actor.MoveX(moveX, null);
                    }
                }
            }
        }
        if (moveY != 0)
        {
            //Do y-axis movement 
        }
        //Re-enable collisions for this Solid 
        Collidable = true;
*/
    }
}
