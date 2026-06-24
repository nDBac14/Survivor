public interface IState
{
    void Enter();   // gọi 1 lần khi vào state
    void Tick();    // gọi mỗi frame khi đang ở state
    void Exit();    // gọi 1 lần khi rời state
}