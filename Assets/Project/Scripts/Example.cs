using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts
{
    public class Example : MonoBehaviour
    {
        private EnemyDestroyProcessService _enemyDestroyProcessService;
        private EnemyCreator _enemyCreator;

        private void Awake()
        {
            _enemyDestroyProcessService = new EnemyDestroyProcessService();
            _enemyCreator = new EnemyCreator();
        }

        private void Update()
        {
            _enemyDestroyProcessService.UpdateEnemiesList();
            Debug.Log("Enemy count: " + _enemyDestroyProcessService.Count);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Added logic enemy (died immediately)");
                _enemyDestroyProcessService.Add(_enemyCreator.Create(),() => true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Added timer enemy (died after 5 sec)");
                float deathTime = 5 + Time.time;
                _enemyDestroyProcessService.Add(_enemyCreator.Create(),() => Time.time > deathTime);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Added agoraphobic enemy (died if there is more then 4 enemies)");
                _enemyDestroyProcessService.Add(_enemyCreator.Create(),() => _enemyDestroyProcessService.Count > 4);
            }
        }
    }
}
