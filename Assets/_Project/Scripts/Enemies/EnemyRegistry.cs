using System.Collections.Generic;
using UnityEngine;

public static class EnemyRegistry
{
    private static readonly List<Transform> enemies = new List<Transform>();
    public static IReadOnlyList<Transform> All => enemies;

    public static void Register(Transform t) => enemies.Add(t);
    public static void Unregister(Transform t) => enemies.Remove(t);
    public static void Clear() => enemies.Clear();

    public static Transform GetNearest(Vector2 from, float maxRange)
    {
        Transform nearest = null;
        float minSqr = maxRange * maxRange;
        for (int i = 0; i < enemies.Count; i++)
        {
            float sqr = ((Vector2)enemies[i].position - from).sqrMagnitude;
            if (sqr < minSqr) { minSqr = sqr; nearest = enemies[i]; }
        }
        return nearest;
    }
}