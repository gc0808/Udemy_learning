using UnityEngine;

public class PlayerFallState : PlayerAiredState 
{
    public PlayerFallState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    
    public override void Update()
    {
        base.Update();

        //if player detecting is on the ground, if yes, go to idle
        if (player.groundDetected)
            stateMachine.changeState(player.idleState);

        if (player.wallDetected)
            stateMachine.changeState(player.wallSlideState);
    }
}
