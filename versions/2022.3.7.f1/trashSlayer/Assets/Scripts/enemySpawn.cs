using System.Collections;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemies;

    [SerializeField]
    private GameObject Boss;

    [SerializeField]
    private float enemySpawnInterval = 2f;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2,2f };

    private int currentLevel = 0;
    private int spawnCount = 0;

    private void Start() {
        StartCoroutine("EnemyRoutine");
    }

    public void stopRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3);

        while (true) {
            if (GameManager.instance.gameOver)
            {
                stopRoutine();
                yield return null;
            }
            for (int i = 0; i < 5; i++) {
                int idx = Random.Range(0, currentLevel);
                SpawnEnemy(arrPosX[i], idx);
            }
            spawnCount++;
            if (spawnCount % 2 == 0) {
                currentLevel++;
                if (currentLevel >= Enemies.Length) {
                    currentLevel = 0;
                    Instantiate(Boss);
                }
            }
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    void SpawnEnemy(float posX, int idx) {
        if (Random.Range(0, 5) == 0) {
            idx++;
        }
        if (idx >= Enemies.Length) {
            idx = Enemies.Length - 1;
        } else if (idx < currentLevel - 3) {
            idx = currentLevel;
        }
        Vector3 position = new Vector3(posX, transform.position.y, 0);
        GameObject enemy = Instantiate(Enemies[idx], position, Quaternion.identity);
        enemy enemyScript = enemy.GetComponent<enemy>();
        enemyScript.setMoveSpeed(currentLevel * 0.1f);
    }
}
