using UnityEngine;

public class PlayerAiredState : EntityState
{
    public PlayerAiredState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0)
            player.setVelocity(player.moveInput.x * (player.moveSpeed * player.inAirMoveMutiplier), rb.linearVelocity.y);

        if (input.Player.Attack.WasPressedThisFrame())
            stateMachine.changeState(player.jumpAttackState);
    }
}
