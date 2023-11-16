using UnityEngine;
using UnityEngine.UI;

public class LevelBtnView : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private Button levelBtn;

    void Start()
    {
        levelBtn = GetComponent<Button>();
        levelBtn.onClick.AddListener(LoadLevel);
        levelBtn.interactable = false;
        if(levelNumber == 1)
        {
            levelBtn.interactable = true;
        }

        if(levelNumber != 1 && LevelManager.Instance.GetLevelStatus(levelNumber) == LevelStatus.UNLOCKED)
        {
            levelBtn.interactable = true;
        }
    }

    private void LoadLevel()
    {
        SceneController.instance.LoadScene(levelNumber);
    }
}
