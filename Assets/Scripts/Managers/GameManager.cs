using UnityEngine;
using Assets.Scripts.Models;

public class GameManager : MonoBehaviour
{
    #region fields

    private static GameManager instance;

    #endregion

    #region properties

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("GameManager");
                instance = gameObject.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public Player Player { get; private set; }

    #endregion

    private void Awake()
    {
        Player = new Player();
        DontDestroyOnLoad(gameObject);
    }
}