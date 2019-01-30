using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Player playerScript;
    public static float speed = 40;
    public float lifeTime;

    public GameObject explosion;

    public int damage;

    //public GameObject effect;

    //public GameObject soundObject;

    private void Start() {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Invoke("DestroyProjectile", lifeTime);
        //Instantiate(soundObject, transform.position, transform.rotation);
    }

    void Update() {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.tag == "Player") {
            playerScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

}
