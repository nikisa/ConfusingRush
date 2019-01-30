using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {


    public float speed;
    private float attackTime;


    public Transform shotPoint;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveAmount;

    public GameObject projectile;
    public GameObject shock;

    public float timeBetweenShots;

    private float shotTime;

    Animator cameraAnim;

    // Use this for initialization
    void Start() {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("SpeedUp", 0.1f , 10f);

    }

    // Update is called once per frame
    void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("EnemyHorizontal"), 0);
        moveAmount = moveInput.normalized * speed;
        
        if (Input.GetMouseButton(0)) { //0 = Left Mouse Button -- 1 = Right Mouse Button
            if (Time.time >= shotTime) {
                //cameraAnim.SetTrigger("shake");
                shotTime = Time.time + timeBetweenShots;
                anim.SetTrigger("attack");
            }
        }

        else if (Input.GetMouseButton(1)) { //0 = Left Mouse Button -- 1 = Right Mouse Button
            if (Time.time >= shotTime) {
                //cameraAnim.SetTrigger("shake");
                shotTime = Time.time + timeBetweenShots;
                anim.SetTrigger("shock");
            }
        }

        

    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }


    public void RangedAttack() {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }

    public void ShockAttack() {
        Instantiate(shock, shotPoint.position, transform.rotation);
    }

    void SpeedUp() {
        Debug.Log(Projectile.speed);
        Debug.Log(Shock.speed);
        Shock.speed += (Shock.speed * 25) / 100;
        Projectile.speed += (Projectile.speed * 25) / 100;

    }

}
