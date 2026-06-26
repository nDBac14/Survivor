using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Các màn hình")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject hudPanel; 

    private StateMachine sm;

    // các state (tạo 1 lần) — dùng lại IState/StateMachine của Phase 8
    public MenuState Menu { get; private set; }
    public PlayingState Playing { get; private set; }
    public PausedState Paused { get; private set; }
    public GameOverState GameOver { get; private set; }

    void Awake()
    {
        EnemyRegistry.Clear();          // dọn danh sách cũ khi vào màn (an toàn khi restart)

        sm = new StateMachine();
        Menu = new MenuState(this);
        Playing = new PlayingState(this);
        Paused = new PausedState(this);
        GameOver = new GameOverState(this);
    }

    void OnEnable() => GameEvents.PlayerDied += HandlePlayerDied;
    void OnDisable() => GameEvents.PlayerDied -= HandlePlayerDied;

    void Start() => sm.ChangeState(Menu);   // bắt đầu ở Menu

    void Update() => sm.Tick();

    public void ChangeState(IState next) => sm.ChangeState(next);

    private void HandlePlayerDied()
    {
        if (sm.Current == Playing || sm.Current == Paused)
            ChangeState(GameOver);
    }

    // ===== Bật/tắt UI (null-safe để khỏi lỗi khi chưa gán) =====
    public void ShowMenu(bool s) { if (menuPanel) menuPanel.SetActive(s); }
    public void ShowPause(bool s) { if (pausePanel) pausePanel.SetActive(s); }
    public void ShowGameOver(bool s) { if (gameOverPanel) gameOverPanel.SetActive(s); }
    public void ShowHUD(bool s) { if (hudPanel) hudPanel.SetActive(s); }

    // ===== Các nút bấm gọi (gắn trong Inspector) =====
    public void OnStartButton() => ChangeState(Playing);
    public void OnResumeButton() => ChangeState(Playing);
    public void OnRestartButton() => RestartGame();
    public void OnQuitButton() => Application.Quit();

    private void RestartGame()
    {
        Time.timeScale = 1f;   // QUAN TRỌNG: gỡ đóng băng trước khi tải lại
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}