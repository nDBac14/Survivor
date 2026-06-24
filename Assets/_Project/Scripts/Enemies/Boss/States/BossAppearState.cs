using UnityEngine;

public class BossAppearState : IState
{
    private readonly BossController boss;
    private float timer;

    public BossAppearState(BossController boss) { this.boss = boss; }

    public void Enter() { timer = boss.appearDelay; }   // dừng 1 chút khi mới hiện

    public void Tick()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) boss.ChangeState(boss.Chase);  // hết → chuyển sang đuổi
    }

    public void Exit() { }
}