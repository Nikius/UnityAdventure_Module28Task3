using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class EnemyContainerService
    {
        private readonly List<Enemy> _enemies = new();
        
        public int Count => _enemies.Count;

        public void AddLogicEnemy(bool isAlreadyDead)
        {
            Enemy enemy = new Enemy(() => isAlreadyDead);
            AddEnemy(enemy);
        }

        public void AddTimerEnemy(float timeOfLife)
        {
            float deathTime = timeOfLife + Time.time;
            Enemy enemy = new Enemy(() => Time.time > deathTime );
            AddEnemy(enemy);
        }

        public void AddAgoraphobicEnemy(int maxNeighbours)
        {
            Enemy enemy = new Enemy(() => _enemies.Count > maxNeighbours + 1 );
            AddEnemy(enemy);
        }

        public void UpdateEnemiesList()
        {
            for (int i = 0; i < _enemies.Count; i++)
                if (_enemies[i].IsDead())
                    _enemies.Remove(_enemies[i]);
        }

        private void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }
    }
}