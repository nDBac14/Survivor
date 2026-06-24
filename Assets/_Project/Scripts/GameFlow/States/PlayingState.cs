using UnityEngine;

public class PlayingState : IState
{
    private readonly GameManager gm;
    public PlayingState(GameManager gm) { this.gm = gm; }

    public void Enter()
    {
        Time.timeScale = 1f;        // chạy
        gm.ShowHUD(true);
    }
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // nhấn ESC → tạm dừng
            gm.ChangeState(gm.Paused);
    }
    public void Exit() { }
}