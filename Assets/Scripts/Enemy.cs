using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Hittable {
    public Transform bullet;
    public int score;

    EnemyManager enemyManager;

    private void Start() {
        enemyManager = transform.parent.GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Border")) {
            enemyManager.SetMoveY();
        }
    }

    public void FireBullet() {
        if(this != null) {
            Transform t = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1f), Quaternion.identity);
            t.GetComponent<Bullet>().speed *= -1;
        }
    }

    public void GetHit() {
        enemyManager.RemoveEnemy(this);
        UIManager.instance.AddScore(gameObject.GetComponent<Enemy>().score);
        Destroy(gameObject);
    }
}
