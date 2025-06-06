using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Scripts
{
    public class EnemyContainerService
    {
        private readonly Dictionary<Enemy, Func<bool>> _enemies = new();
        
        public int Count => _enemies.Count;

        public void AddLogicEnemy(bool isAlreadyDead)
        {
            Enemy enemy = new Enemy();
            AddEnemy(enemy, () => isAlreadyDead);
        }

        public void AddTimerEnemy(float timeOfLife)
        {
            float deathTime = timeOfLife + Time.time;
            Enemy enemy = new Enemy();
            AddEnemy(enemy, () => Time.time > deathTime);
        }

        public void AddAgoraphobicEnemy(int maxNeighbours)
        {
            Enemy enemy = new Enemy();
            AddEnemy(enemy, () => _enemies.Count > maxNeighbours + 1);
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

        private void AddEnemy(Enemy enemy, Func<bool> isDeadCondition)
        {
            _enemies.Add(enemy, isDeadCondition);
        }
    }
}