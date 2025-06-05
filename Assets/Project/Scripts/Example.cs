using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts
{
    public class Example : MonoBehaviour
    {
        private EnemyContainerService _enemyContainerService;

        private void Awake()
        {
            _enemyContainerService = new EnemyContainerService();
        }

        private void Update()
        {
            _enemyContainerService.UpdateEnemiesList();
            Debug.Log("Enemy count: " + _enemyContainerService.Count);

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Added logic enemy (died immediately)");
                _enemyContainerService.AddLogicEnemy(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Added timer enemy (died after 5 sec)");
                _enemyContainerService.AddTimerEnemy(5);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Added agoraphobic enemy (died if has more then 3 neighbours)");
                _enemyContainerService.AddAgoraphobicEnemy(3);
            }
        }
    }
}
