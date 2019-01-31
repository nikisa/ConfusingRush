using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCoop : MonoBehaviour {


    public float speed;


    private Rigidbody2D rb;
    private Animator anim;

    public int health;

    private Vector2 moveAmount;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public static float time = 0;

    private int P1W;

    public Text ScoreP1;

    public bool isShocked = false;

    //public Animator hurtAnim;


    // Use this for initialization
    void Start() {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update() {

        Vector2 moveInput = new Vector2(0, 0);

            if (!isShocked) {
                moveInput = new Vector2(Input.GetAxisRaw("VerticalCoop"), Input.GetAxisRaw("HorizontalCoop"));
            }
            else {
                moveInput = new Vector2(Input.GetAxisRaw("HorizontalCoop"), Input.GetAxisRaw("VerticalCoop"));
            }
            moveAmount = moveInput.normalized * speed;
        

        if (moveInput != Vector2.zero) {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate() {

        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
        UpdateHealthUI(health);
        


        if (health <= 0) {//DEAD

            P1W++;
            Debug.Log(TurnManager.turn);
            Projectile.speed = 40;
            Shock.speed = 40;
            SceneManager.LoadScene(3);
            time = TimerCoop.t;

        }

    }

    public void TakeShock() {
        isShocked = !isShocked;

    }



    void UpdateHealthUI(int currentHealth) {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < currentHealth) {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }
        }
    }


    public void Heal(int healAmount) {

        if (health + healAmount > 3) {
            health = 5;
        }
        else {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

}
