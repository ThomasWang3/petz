using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Thomas Wang
public class EnemyManager : MonoBehaviour
{
    [SerializeField] public GameObject[] enemies;
    [SerializeField] private int enemiesLeft;

    // Start is called before the first frame update
    void Awake()
    {
        // Debug.Log("enemiesLeft: " + enemiesLeft);
        // Debug.Log("enemies: " + enemies[0]);
        if(enemiesLeft < 3) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if(enemiesLeft == 0) {
    //        enemies[enemies.Length-1].SetActive(true);
    //    }
    //}

    // public void PrintEnemy(int index) {
    //     enemies[index]
    // }

    public void ReduceEnemyCount(int index) {
        Debug.Log("Reduce Enemy Count");
        Debug.Log("index: " + index);
        enemiesLeft--;
        enemies[index].gameObject.SetActive(false);
        if (enemiesLeft == 0) {
            enemies[enemies.Length - 1].SetActive(true);
        }
    }
}
