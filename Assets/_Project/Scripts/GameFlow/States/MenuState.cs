using UnityEngine;

public class MenuState : IState
{
    private readonly GameManager gm;
    public MenuState(GameManager gm) { this.gm = gm; }

    public void Enter()
    {
        Time.timeScale = 0f;        // game đứng yên ở menu
        gm.ShowMenu(true);
        gm.ShowHUD(false);
    }
    public void Tick() { }
    public void Exit() => gm.ShowMenu(false);
}