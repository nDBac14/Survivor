using UnityEngine;

public class PausedState : IState
{
    private readonly GameManager gm;
    public PausedState(GameManager gm) { this.gm = gm; }

    public void Enter()
    {
        Time.timeScale = 0f;        // dừng
        gm.ShowPause(true);
    }
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // ESC lần nữa → chơi tiếp
            gm.ChangeState(gm.Playing);
    }
    public void Exit() => gm.ShowPause(false);
}