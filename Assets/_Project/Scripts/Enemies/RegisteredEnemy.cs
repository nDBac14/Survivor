using UnityEngine;

public class RegisteredEnemy : MonoBehaviour
{
    void OnEnable() => EnemyRegistry.Register(transform);   
    void OnDisable() => EnemyRegistry.Unregister(transform); 
}