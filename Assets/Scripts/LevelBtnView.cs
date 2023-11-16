using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelBtnView : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private Button levelBtn;

    void Start()
    {
        levelBtn = GetComponent<Button>();
        levelBtn.onClick.AddListener(LoadLevel);
        levelBtn.interactable = false;
        LevelManager.Instance.SetLevelStatus(levelNumber, LevelStatus.LOCKED);

        if (levelNumber == 1 && LevelManager.Instance.GetLevelStatus(1) == LevelStatus.LOCKED)
        {
            levelBtn.interactable = true;
            LevelManager.Instance.SetLevelStatus(1, LevelStatus.UNLOCKED);
        }
        else if(LevelManager.Instance.GetLevelStatus(levelNumber) == LevelStatus.UNLOCKED)
        {
            print(levelNumber + " Unlocked");
            levelBtn.interactable = true;
        }
    }

    private void LoadLevel()
    {
        SceneController.instance.LoadScene(levelNumber);
    }
}
