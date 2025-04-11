using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Speed = 300.0f;
	public float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		if(!IsOnFloor()){
			Velocity += GetGravity() * (float)delta;
		}
		MoveAndSlide();
	}
}
