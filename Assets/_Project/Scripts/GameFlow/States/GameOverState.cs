using UnityEngine;

public class GameOverState : IState
{
    private readonly GameManager gm;
    public GameOverState(GameManager gm) { this.gm = gm; }

    public void Enter()
    {
        Time.timeScale = 0f;
        gm.ShowGameOver(true);
    }
    public void Tick() { }
    public void Exit() => gm.ShowGameOver(false);
}