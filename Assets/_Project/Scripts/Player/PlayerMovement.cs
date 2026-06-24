using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerStats stats;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        // Input cũ (WASD). Phase 1 giáo trình tách ra IInputProvider (Strategy + DIP)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D hoặc mũi tên
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S
        moveInput = moveInput.normalized;             // tránh đi chéo nhanh hơn

        // Lật sprite theo hướng đi
        if (moveInput.x != 0)
            sr.flipX = moveInput.x < 0;
    }

    void FixedUpdate()
    {
        float speed = moveSpeed * (stats != null ? stats.Get(StatType.MoveSpeed) : 1f);
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}