using SDL3;
using SDL3_Physics.Core;
using System.Numerics;
using Math = SDL3_Physics.Core.Math;

namespace SDL3_Physics.Entity;

class Player : Actor
{
    const float MaxSpeed = 300;
    const float Accel = 5000;
    const float gravity = 900;
    const float MaxFallSpeed = 400;
    const float JumpPower = -500;

    private Vector2 velotity;


    public Player()
    {
        Size.X = 10;
        Size.Y = 10;
    }

    public override void Update()
    {
        int inputX = 0;

        if (Game.keyInput.Contains(SDL.Keycode.A))
            inputX--;
        if (Game.keyInput.Contains(SDL.Keycode.D))
            inputX++;
        if (Game.keyInput.Contains(SDL.Keycode.Space))
            velotity.Y = JumpPower;



        velotity.X = Math.Approach(velotity.X, inputX * MaxSpeed, Accel * Time.Deltatime);
        velotity.Y = Math.Approach(velotity.Y, MaxFallSpeed, gravity * Time.Deltatime);

        MoveX(velotity.X * Time.Deltatime, () => Console.WriteLine("hit"));
        MoveY(velotity.Y * Time.Deltatime, () => Console.WriteLine("onGround"));
    }
}
