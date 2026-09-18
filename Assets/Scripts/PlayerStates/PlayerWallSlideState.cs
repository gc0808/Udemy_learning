using UnityEngine;

public class PlayerWallSlideState : EntityState
{
    public PlayerWallSlideState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        HandleWallSlide();

        if (input.Player.Jump.WasPressedThisFrame())
            stateMachine.changeState(player.wallJumpState);

        if (player.wallDetected == false)
            stateMachine.changeState(player.fallState);

        if (player.groundDetected)
        {
            stateMachine.changeState(player.idleState);
            player.Flip();
        }
    }

    private void HandleWallSlide()
    {
        if (player.moveInput.y < 0)
            player.setVelocity(player.moveInput.x, rb.linearVelocity.y);
        else
            player.setVelocity(player.moveInput.x, rb.linearVelocity.y * player.wallSlideSlowMultiplier);

    }
}
