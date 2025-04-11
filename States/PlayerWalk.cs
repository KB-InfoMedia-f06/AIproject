using Godot;
using System;

public partial class PlayerWalk : State
{
    [Export]
    Player player;

    public override void Enter()
    {
        player.sprite.Play("walk");
        GD.Print("enter walk");
    }

    public override void Exit()
    {
        player.sprite.Stop();
        GD.Print("exit walk");
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
        } else {
            EmitSignal(State.SignalName.Transitioned, this, "Idle");
        }
        player.Velocity = velocity;

        if(Input.IsActionJustPressed("Jump")){
            EmitSignal(State.SignalName.Transitioned, this, "Jump");
        }
    }

}
