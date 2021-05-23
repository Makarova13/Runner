using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
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
}
