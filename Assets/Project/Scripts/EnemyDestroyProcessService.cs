using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Scripts
{
    public class EnemyDestroyProcessService
    {
        private readonly Dictionary<Enemy, Func<bool>> _enemies = new();
        
        public int Count => _enemies.Count;
        
        public void Add(Enemy enemy, Func<bool> condition)
        {
            _enemies.Add(enemy, condition);
        }
        
        public void UpdateEnemiesList()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                KeyValuePair<Enemy, Func<bool>> enemyKvp = _enemies.ElementAt(i);
                
                if (enemyKvp.Value())
                    _enemies.Remove(enemyKvp.Key);
            }
        }
    }
}