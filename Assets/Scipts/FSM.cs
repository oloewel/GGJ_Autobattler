using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public abstract class FSM : MonoBehaviour
{
    protected IState Current {get; private set;}

    void Update() => Current?.OnUpdate();

    protected void ChangeState(IState next)
    {
        if (Current == next) return;
        Current?.OnExit();
        (Current = next).OnEnter();
    }
}

class IdleState : IState
{
    public void OnEnter()
    {
        // was passiert wenn man in den Idle wechselt?
    }

    public void OnExit()
    {
        // was passiert wenn man den Zustand verlässt?
    }

    public void OnUpdate()
    {
        /* Ignored */
    }
}

class Player : FSM
{
    void idle()
    {
        ChangeState(new IdleState());
    }
}