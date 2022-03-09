using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int enemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesLeft == 0) {
            enemies[enemies.Length-1].SetActive(true);
        }
    }

    public void ReduceEnemyCount() {
        enemiesLeft--;
    }
}
