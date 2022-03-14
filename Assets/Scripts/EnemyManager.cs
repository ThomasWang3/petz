using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour {
    [SerializeField] public List<GameObject> enemies;
    [SerializeField] private int enemiesLeft;
    [SerializeField] private List<bool> activeEnemies;
    [SerializeField] private static EnemyManager em;
    [SerializeField] private GameObject doorPortal;

    // Start is called before the first frame update
    void Awake() {
        // Debug.Log("enemiesLeft: " + enemiesLeft);
        // Debug.Log("enemies: " + enemies[0]);
            //DontDestroyOnLoad(this.gameObject);
            //if(em == null) {
            //    Debug.Log("first instance");
            //    em = this;
            //    Debug.Log("enemies size: " + enemies.Count);
            //} else {
            //    Debug.Log("second instance");
            //    em.SetActive();
            //    Destroy(this.gameObject);
            //}
            for (int i = 0; i < enemies.Count; i++) {
                if (enemies[i].activeSelf)
                    activeEnemies.Add(true);
                else
                    activeEnemies.Add(false);
            }
        }

        public void ReduceEnemyCount(int index) {
            activeEnemies[index] = false;
            enemies[index].SetActive(false);
            enemiesLeft--;
            if (enemiesLeft == 0) {
                activeEnemies[activeEnemies.Count - 1] = true;
                enemies[enemies.Count - 1].SetActive(true);
            }
            if(enemiesLeft == -1) {
                doorPortal.SetActive(true);
            }
            //RefreshEnemies();
        }
    }