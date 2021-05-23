using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Common;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private List<GameObject> hearts;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        bestScore.text = GameManager.Instance.Player.BestScore.ToString();
        GameManager.Instance.Player.OnHealthChanged += () => ChangeHealth();
        GameManager.Instance.Player.OnScoreChanged += () => ChangeScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseBottonClick()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void StartButtonClick()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void MenuButtonClick()
    {
        SceneManager.LoadScene(Constants.MenuSceneName, LoadSceneMode.Additive);
    }

    private void ChangeHealth()
    {
        Destroy(hearts[GameManager.Instance.Player.Health]);
    }

    private void ChangeScore()
    {
        score.text = GameManager.Instance.Player.Score.ToString();
    }
}
