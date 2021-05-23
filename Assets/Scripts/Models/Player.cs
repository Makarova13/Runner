using System;

namespace Assets.Scripts.Models
{
    public class Player
    {
        public event Action OnHealthChanged;
        public event Action OnScoreChanged;

        #region fields

        private int health = 3;
        private int score = 0;
        private int bestScore = 0;
        private readonly float startRunSpeed;

        #endregion

        #region properties

        public float RunSpeed { get; set; }

        public int BestScore
        {
            get
            {
                bestScore = bestScore > score ? bestScore : score;
                return bestScore;
            }
            set
            {
                bestScore = value;
            }
        }

        public int Health
        {
            get 
            {
                return health;
            }
            set
            {
                health = value;
                OnHealthChanged?.Invoke();
            } 
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnScoreChanged?.Invoke();
            }
        }

        #endregion

        public Player(float runSpeed = 1)
        {
            RunSpeed = runSpeed;
            startRunSpeed = runSpeed;
        }

        public void Reset()
        {
            RunSpeed = startRunSpeed;
            score = 0;
            health = 3;
        }
    }
}
