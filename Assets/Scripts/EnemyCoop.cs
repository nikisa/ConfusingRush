using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoop : MonoBehaviour {

    public float stopDistance;

    private float attackTime;

    private Animator anim;


    public Transform shotPoint;

    public GameObject enemyBullet;
    public GameObject enemyShock;

    public Transform player;

    public float speed;

    public float timeBetweenAttacks;

    // Use this for initialization
    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {

        if (player != null) {
            //if (Vector2.Distance(transform.position, player.position) > stopDistance) {
                //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            //}

            if (Time.time >= attackTime) {
                attackTime = Time.time + timeBetweenAttacks;
                anim.SetTrigger("attack");
            }

        }

    }

    public void RangedAttack() {
        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        shotPoint.rotation = rotation;

        int randomAttack = Random.Range(1,11);

        if (randomAttack % 2 == 0) {
            Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
        }
        else {
            Instantiate(enemyShock, shotPoint.position, shotPoint.rotation);
        }

        

    }

}


