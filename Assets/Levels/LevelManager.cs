using System.ComponentModel;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum LevelStatus
{
    LOCKED,
    UNLOCKED
}

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;
    public static LevelManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    public LevelStatus GetLevelStatus(int index)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt("Level" + index.ToString(), 0);
        return levelStatus;
    }

    public void SetLevelStatus(int index, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt("Level" + index.ToString(), (int)levelStatus);
    }

    public void UnlockLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        print(nextIndex + " Unlocked");

        if (nextIndex <= 3)
        {
            SetLevelStatus(nextIndex, LevelStatus.UNLOCKED);
        }
    }
}
