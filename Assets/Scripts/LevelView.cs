using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelView : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private Button levelBtn;

    void Start()
    {
        levelBtn = GetComponent<Button>();
        levelBtn.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        SceneController.instance.LoadScene(levelNumber);
    }
}
