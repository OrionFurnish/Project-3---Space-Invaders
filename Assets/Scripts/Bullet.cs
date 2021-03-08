using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public List<string> targets;

    void Update() {
        Vector3 movement = new Vector3(0f, speed*Time.deltaTime);
        transform.Translate(movement);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(targets.Contains(collision.gameObject.tag)) {
            Hittable hittable = collision.gameObject.GetComponent<Hittable>();
            if (hittable != null) {
                collision.gameObject.GetComponent<Hittable>().GetHit();
            }
            Destroy(gameObject);
        }
    }
}
