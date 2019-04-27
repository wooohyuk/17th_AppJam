using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    Transform canvasParent;

    [SerializeField]
    Transform player;

    [Space(10)]

    [SerializeField]
    GameObject[] enemyPrefabs;

    public void CreateEnemy(EEnemyType type, Vector3 pos)
    {
        var enemy = Instantiate(enemyPrefabs[(int)type], canvasParent);
        enemy.transform.localPosition = pos;
        enemy.GetComponentInChildren<EnemyMovement>().SetTarget(player);

        EnemyHPManager.GetInstance().enemyList.Add(enemy.GetComponentInChildren<EnemyHealth>());
    }


    IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 7.0f));

            int randomCount = Random.Range(1, 3);

            for (int i = 0; i < randomCount; i++)
            {
                Vector3 randomPos = Random.insideUnitCircle * Random.Range(1.0f, 2.0f);
                EEnemyType randomType = (EEnemyType)Random.Range(0, (int)EEnemyType._COUNT);
                CreateEnemy(randomType, transform.localPosition + randomPos);
            }
        }
    }

    void Start()
    {
        StartCoroutine(Spawning());
    }

}
