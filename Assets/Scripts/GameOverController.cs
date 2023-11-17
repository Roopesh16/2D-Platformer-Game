using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button quitBtn;

    void Start()
    {
        restartBtn.onClick.AddListener(RestartLevel);
        quitBtn.onClick.AddListener(LoadLobby);
        gameObject.SetActive(false);
    }

    public void EnableGameOver()
    {
        gameObject.SetActive(true);
    }

    private void RestartLevel()
    {
        SceneController.instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadLobby()
    {
        SceneController.instance.LoadScene(0);
    }
}
