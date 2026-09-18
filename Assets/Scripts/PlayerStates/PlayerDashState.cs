using UnityEngine;

public class PlayerDashState : EntityState
{
    public PlayerDashState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    private float originalGravityScale;
    private int dashDirection;

    public override void Enter()
    {
        base.Enter();

        dashDirection = player.moveInput.x != 0 ? ((int)player.moveInput.x) : player.facingDirection;
        stateTimer = player.dashDuration;

        originalGravityScale = rb.gravityScale;
        rb.gravityScale = 0;
    }

    public override void Update()
    {
        base.Update();

        CancelDashIfNeeded();
        player.setVelocity(player.dashSpeed * dashDirection, 0);

        if (stateTimer < 0)
        {
            if (player.groundDetected)
                stateMachine.changeState(player.idleState);
            else
                stateMachine.changeState(player.fallState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.setVelocity(0,0);
        rb.gravityScale = originalGravityScale;
    }

    public void CancelDashIfNeeded()
    {
        if (player.wallDetected)
        {
            if (player.groundDetected)
                stateMachine.changeState(player.idleState);
            else
                stateMachine.changeState(player.wallSlideState);
        }

    }
}
