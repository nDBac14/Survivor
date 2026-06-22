using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate = 2f;  // số phát mỗi giây
    [SerializeField] private float range = 8f;

    private float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            Transform target = FindNearestEnemy();
            if (target != null)
            {
                Fire(target);
                cooldown = 1f / fireRate;
            }
        }
    }

    Transform FindNearestEnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearest = null;
        float minDist = range;
        foreach (var e in enemies)
        {
            float d = Vector2.Distance(transform.position, e.transform.position);
            if (d < minDist) { minDist = d; nearest = e.transform; }
        }
        return nearest;
    }

    void Fire(Transform target)
    {
        Vector2 dir = target.position - transform.position;
        var proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        proj.GetComponent<Projectile>().Init(dir);
    }
}