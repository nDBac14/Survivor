public static class GameEvents
{
    public static event System.Action EnemyKilled;
    public static event System.Action<Health> BossSpawned;
    public static event System.Action BossDespawned;
    public static event System.Action PlayerDied;

    public static void RaiseEnemyKilled() => EnemyKilled?.Invoke();
    public static void RaiseBossSpawned(Health bossHealth) => BossSpawned?.Invoke(bossHealth);
    public static void RaiseBossDespawned() => BossDespawned?.Invoke();
    public static void RaisePlayerDied() => PlayerDied?.Invoke();
}