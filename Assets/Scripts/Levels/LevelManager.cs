using UnityEngine;
using UnityEngine.SceneManagement;

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
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // private void Start()
    // {
    //     PlayerPrefs.DeleteAll();
    // }

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

        if (nextIndex <= 5)
        {
            SetLevelStatus(nextIndex, LevelStatus.UNLOCKED);
        }
    }
}
