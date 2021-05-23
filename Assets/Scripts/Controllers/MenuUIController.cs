using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Common;

public class MenuUIController : MonoBehaviour
{
    [SerializeField]
    private Text bestScore;
    [SerializeField]
    private Text score;

    void Start()
    {
        bestScore.text = GameManager.Instance.Player.BestScore.ToString();
        score.text = GameManager.Instance.Player.Score.ToString();
    }

    public void ButtonPlayClick()
    {
        SceneManager.LoadScene(Constants.GameSceneName, LoadSceneMode.Additive);
    }

    public void CloseButtonClick()
    {
        Application.Quit();
    }
}