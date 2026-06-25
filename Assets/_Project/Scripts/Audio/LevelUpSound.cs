using UnityEngine;

public class LevelUpSound : MonoBehaviour
{
    [SerializeField] private PlayerExperience experience;
    [SerializeField] private AudioClip clip;

    void OnEnable() => experience.OnLevelUp += Play;
    void OnDisable() => experience.OnLevelUp -= Play;

    private void Play(int level)
    {
        if (AudioManager.Instance) AudioManager.Instance.PlaySFX(clip);
    }
}