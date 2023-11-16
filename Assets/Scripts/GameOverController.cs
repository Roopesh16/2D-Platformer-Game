using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button lobbyBtn;

    void Start()
    {
        restartBtn.onClick.AddListener(RestartLevel);
        lobbyBtn.onClick.AddListener(LoadLobby);
        gameObject.SetActive(false);
    }

    public void EnableGameOver()
    {
        gameObject.SetActive(true);
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
