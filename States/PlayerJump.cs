using Godot;
using System;

public partial class PlayerJump : State
{
	 [Export]
    Player player;

    public override void Enter()
    {
		player.Velocity = new Vector2(0, player.JumpVelocity);
        player.sprite.Play("jump");
        GD.Print("enter jump");
    }

    public override void Exit()
    {
        player.sprite.Stop();
        GD.Print("exit jump");
    }

    public override void Update(double delta)
    {

    }

    public override void PhysicsUpdate(double delta)
    {
        Vector2 velocity = player.Velocity;
        Vector2 direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        if(direction.X != 0){
            velocity.X = MathF.Round(direction.X) * player.Speed;
        } 
		player.Velocity = velocity;

		if(player.IsOnFloor()){
			EmitSignal(State.SignalName.Transitioned, this, "Idle");
		}
    }
}
