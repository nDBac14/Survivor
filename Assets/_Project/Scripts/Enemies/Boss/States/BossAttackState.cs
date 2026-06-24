using UnityEngine;

public class BossAttackState : IState
{
    private readonly BossController boss;
    private float timer;

    public BossAttackState(BossController boss) { this.boss = boss; }

    public void Enter()
    {
        timer = boss.attackDuration;
        boss.DoAttack();                                // gây sát thương ngay khi vào
    }

    public void Tick()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) boss.ChangeState(boss.Chase);  // đánh xong → đuổi tiếp
    }

    public void Exit() { }
}