using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject levels;

    void Start()
    {
        playButton.onClick.AddListener(PlayBtn);
        quitButton.onClick.AddListener(QuitBtn);
        levels.SetActive(false);
    }

    private void QuitBtn()
    {
        Application.Quit();
    }

    private void PlayBtn()
    {
        AudioManager.Instance.PlaySfx(AudioTypes.CLICK);
        playButton.gameObject.SetActive(false);
        levels.SetActive(true);
    }
}
