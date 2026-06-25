using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class BossController : MonoBehaviour
{
    [Header("Di chuyển")]
    public float chaseSpeed = 2.5f;
    public float enrageSpeed = 4.5f;       // tốc độ khi nổi điên

    [Header("Tấn công")]
    public float attackRange = 1.5f;
    public float attackDamage = 15f;
    public float attackDuration = 1f;      // thời gian "đứng đánh" trước khi đuổi tiếp

    [Header("Khác")]
    public float appearDelay = 1.2f;
    [Range(0f, 1f)] public float enrageThreshold = 0.5f;  // máu ≤ 50% → nổi điên

    public Transform Player { get; private set; }

    private Rigidbody2D body;
    private Health health;
    private StateMachine sm;
    private bool enraged;
    private float currentSpeed;

    // các state (tạo 1 lần)
    public BossAppearState Appear { get; private set; }
    public BossChaseState Chase { get; private set; }
    public BossAttackState Attack { get; private set; }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        sm = new StateMachine();
        Appear = new BossAppearState(this);
        Chase = new BossChaseState(this);
        Attack = new BossAttackState(this);
    }

    void OnEnable()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Player = p ? p.transform : null;

        enraged = false;
        currentSpeed = chaseSpeed;

        health.OnDamaged += CheckEnrage;
        GameEvents.RaiseBossSpawned(health);   // báo cho thanh máu hiện ra
        sm.ChangeState(Appear);                // bắt đầu ở state Xuất hiện
    }

    void OnDisable()
    {
        health.OnDamaged -= CheckEnrage;
        GameEvents.RaiseBossDespawned();       // báo cho thanh máu ẩn đi
    }

    void Update() => sm.Tick();

    public void ChangeState(IState next) => sm.ChangeState(next);

    public float DistanceToPlayer() =>
        Player ? Vector2.Distance(transform.position, Player.position) : 999f;

    public void MoveTowardsPlayer()
    {
        if (Player == null) return;
        Vector2 dir = ((Vector2)Player.position - body.position).normalized;
        body.MovePosition(body.position + dir * currentSpeed * Time.deltaTime);
    }

    public void DoAttack()
    {
        if (DistanceToPlayer() <= attackRange &&
            Player.TryGetComponent<Health>(out var hp))
            hp.TakeDamage(attackDamage);
        if (ScreenShake.Instance) 
            ScreenShake.Instance.Shake(0.4f);
    }

    private void CheckEnrage(float pct)
    {
        if (!enraged && pct <= enrageThreshold)
        {
            enraged = true;
            currentSpeed = enrageSpeed;     // nhanh hơn
            attackDuration *= 0.6f;         // đánh dồn hơn
        }
    }
}