public class StateMachine
{
    private IState current;
    public IState Current => current;

    public void ChangeState(IState next)
    {
        if (next == current) return;
        current?.Exit();
        current = next;
        current.Enter();
    }

    public void Tick() => current?.Tick();
}