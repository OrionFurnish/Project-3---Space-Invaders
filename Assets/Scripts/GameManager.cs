using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public Transform player; // Player prefab
    public Transform playerSpawner;
    public UIManager uiManager;
    public EnemyManager enemyManager;
    public BarricadeSpawner[] barricadeSpawners;

    private void Start() {
        instance = this;
        StartCoroutine(RestartGame());
    }

    public static void Restart() {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.RestartGame());
    }

    IEnumerator RestartGame() {
        uiManager.SetScoreTableActive(true);
        enemyManager.DestroyEnemies();
        foreach (BarricadeSpawner barricadeSpawner in barricadeSpawners) {
            barricadeSpawner.DestroyBarricade();
        }
        uiManager.ResetScore();
        yield return new WaitForSeconds(5f);
        uiManager.SetScoreTableActive(false);
        SpawnPlayer();
        enemyManager.Reset();
        foreach(BarricadeSpawner barricadeSpawner in barricadeSpawners) {
            barricadeSpawner.SpawnBarricade();
        }
    }

    void SpawnPlayer() {
        Instantiate(player, playerSpawner);
    }
}
