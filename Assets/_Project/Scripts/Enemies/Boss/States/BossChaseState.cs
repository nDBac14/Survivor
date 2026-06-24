using UnityEngine;

public class BossChaseState : IState
{
    private readonly BossController boss;

    public BossChaseState(BossController boss) { this.boss = boss; }

    public void Enter() { }

    public void Tick()
    {
        if (boss.Player == null) return;

        boss.MoveTowardsPlayer();                       // tiến về phía player

        if (boss.DistanceToPlayer() <= boss.attackRange)
            boss.ChangeState(boss.Attack);              // đủ gần → đánh
    }

    public void Exit() { }
}