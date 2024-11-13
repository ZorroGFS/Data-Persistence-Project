using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] TMP_Text topScoreText;
    [SerializeField] TMP_InputField playerNameInput;

    private void Start()
    {
        if (DataManager.Instance != null)
        {
            playerNameInput.text = DataManager.Instance.playerName;
            if (DataManager.Instance.topScore.score != 0)
            {
                topScoreText.text = DataManager.Instance.topScore.playerName + ": " + DataManager.Instance.topScore.score;
            }
            else
            {
                topScoreText.text = "";
            }
        }
    }

    public void StartClick()
    {
        DataManager.Instance.playerName = playerNameInput.text;
        DataManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void QuitClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
