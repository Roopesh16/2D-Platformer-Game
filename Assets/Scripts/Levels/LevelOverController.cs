using UnityEngine.UI;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private GameObject levelOver;
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button lobbyBtn;

    private void Start()
    {
        restartBtn.onClick.AddListener(RestartLevel);
        lobbyBtn.onClick.AddListener(LoadLobby);
        levelOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            AudioManager.Instance.PlaySfx(AudioTypes.LEVEL_COMPLETE);
            other.GetComponent<PlayerController>().enabled = false;
            LevelManager.Instance.UnlockLevel();
            levelOver.SetActive(true);
        }
    }

    private void RestartLevel()
    {
        SceneController.instance.ReloadScene();
    }

    private void LoadLobby()
    {
        SceneController.instance.LoadScene(0);
    }
}
