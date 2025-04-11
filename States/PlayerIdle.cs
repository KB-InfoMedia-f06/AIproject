using Godot;
using System;

public partial class PlayerIdle : State
{
    [Export]
    Player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public override void Enter()
    {
        GD.Print("Enter idle");
    }

    public override void Exit()
    {
        GD.Print("Exit idle");
    }

    public override void Update(double delta)
    {

    }

    public override void PhysicsUpdate(double delta)
    {
        Vector2 velocity = player.Velocity;
        velocity.X = Mathf.MoveToward(player.Velocity.X, 0, player.Speed);
        player.Velocity = velocity;

        if(Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown").X != 0){
            EmitSignal(State.SignalName.Transitioned, this, "Walk");
        }

        if(Input.IsActionJustPressed("Jump")){
            EmitSignal(State.SignalName.Transitioned, this, "Jump");
        }
    }

}
