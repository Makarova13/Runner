using System;

namespace Assets.Scripts.Models
{
    public class Player
    {
        public event Action OnHealthChanged;

        #region fields

        private int health = 3;

        #endregion

        #region properties

        public float RunSpeed { get; set; }

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

        #endregion

        public Player(float runSpeed = 1)
        {
            RunSpeed = runSpeed;
        }
    }
}
