public static class GameEvents
{
    public static event System.Action EnemyKilled;
    public static void RaiseEnemyKilled() => EnemyKilled?.Invoke();
}