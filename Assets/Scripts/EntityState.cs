using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected PlayerInputSet input;
    public float stateTimer;
    public bool triggerCalled;
    public EntityState(Player player, StateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        anim = player.anim;
        rb = player.rb;
        input = player.input;
    }

    public virtual void Enter()
    {
        //everytime state will be changed, enter will be called
        anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Update()
    {
        //run logic of the state here
        stateTimer -= Time.deltaTime;

        anim.SetFloat("yVelocity", rb.linearVelocity.y);

        if (input.Player.Dash.WasPressedThisFrame() && CanDash())
            stateMachine.changeState(player.dashState);
    }

    public virtual void Exit()
    {
        //this will be called, when we exit state and change to a new one
        anim.SetBool(animBoolName, false);
    }

    public void CallAnimationTrggier()
    {
        triggerCalled = true;
    }

    private bool CanDash()
    {
        if (stateMachine.currentState==player.dashState)
            return false;
        if(player.wallDetected)
            return false;
        return true;
    }
}
