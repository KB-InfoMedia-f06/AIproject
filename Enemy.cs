using Godot;
using System;

public partial class Enemy : CharacterBody2D
{

	enum State{
		PLAYER_HIDDEN = 0,
		PLAYER_VISIBLE = 1,
		PLAYER_IN_RANGE = 2
	}

	State currentState;
	Player target;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		target = GetTree().Root.GetNode<Player>("GameScene/Player");
		currentState = State.PLAYER_HIDDEN;
		GD.Print(target);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		switch(currentState){
			case State.PLAYER_HIDDEN:
				Velocity = Vector2.Zero;
				break;
			case State.PLAYER_VISIBLE:
				Velocity = (target.Position - Position).Normalized() * 30;
				break;
			case State.PLAYER_IN_RANGE:
				Velocity = (target.Position - Position).Normalized() * 60;
				break;
		}
		MoveAndSlide();
	}

	public void OnVisionEntered(Node2D node){
		if(node == target){
			GD.Print("enterd vision");
			currentState = State.PLAYER_VISIBLE;
		}
		
	}

	public void OnVisionExited(Node2D node){
		if(node == target){
			GD.Print("exited Vision");
			currentState = State.PLAYER_HIDDEN;
		}
	}

	public void OnAttackRangeEntered(Node2D node){
		if(node == target){
			GD.Print("enterd attack range");
			currentState = State.PLAYER_IN_RANGE;
		}
	}

	public void OnAttackRangeExited(Node2D node){
		if(node == target){
			GD.Print("exited attack range");
			currentState = State.PLAYER_VISIBLE;
		}
	}
}
