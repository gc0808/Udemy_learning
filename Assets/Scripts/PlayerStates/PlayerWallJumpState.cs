using UnityEngine;

public class PlayerWallJumpState : EntityState
{
    public PlayerWallJumpState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.setVelocity(player.wallJumpForce.x * -player.facingDirection, player.wallJumpForce.y);
        stateMachine.changeState(player.jumpState);
    }
    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0)
            stateMachine.changeState(player.fallState);

        if (player.wallDetected)
            stateMachine.changeState(player.wallSlideState);
    }
}
