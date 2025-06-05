using System;

namespace Project.Scripts
{
    public class Enemy
    {
        public readonly Func<bool> IsDead;

        public Enemy(Func<bool> isDead)
        {
            IsDead = isDead;
        }
    }
}