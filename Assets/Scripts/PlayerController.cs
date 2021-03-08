using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Hittable {
    public Transform bullet;
    public float speed;

    private void Update() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f);
        // Collision Testing
        bool hitWall = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + movement, .1f);
        foreach(Collider2D coll in colliders) {
            if(coll.gameObject.CompareTag("Border")) { hitWall = true; }
        }
        if (!hitWall) {
            transform.Translate(movement);
        }

        // Fire Bullet
        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y+1f), Quaternion.identity);
        }
    }

    public void GetHit() {
        Destroy(gameObject);
        GameManager.Restart();
    }
}
