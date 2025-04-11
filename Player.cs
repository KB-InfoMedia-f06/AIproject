using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Speed = 300.0f;
	public float JumpVelocity = -400.0f;
	[Export]
	public AnimatedSprite2D sprite;

    public override void _Process(double delta)
    {
		if(Velocity.X > 0){
			sprite.FlipH = false;
		} else if (Velocity.X < 0){
			sprite.FlipH = true;
		}
    }


	public override void _PhysicsProcess(double delta)
	{
		if(!IsOnFloor()){
			Velocity += GetGravity() * (float)delta;
		}
		MoveAndSlide();
	}
}
