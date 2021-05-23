using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private List<GameObject> hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        GameManager.Instance.Player.OnHealthChanged += () => ChangeHealth();
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

    private void ChangeHealth()
    {
        if(GameManager.Instance.Player.Health > 0)
        {
            Destroy(hearts[GameManager.Instance.Player.Health]);
        }
        else
        {
            Destroy(hearts[GameManager.Instance.Player.Health]);
            PauseBottonClick();
        }
    }
}
