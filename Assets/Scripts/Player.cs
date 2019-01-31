using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


    public float speed;

    public static bool P1Winning = false;
 

    private Rigidbody2D rb;
    private Animator anim;

    public int health;

    private Vector2 moveAmount;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int P1W, P2W;

    public Text ScoreP1;
    public Text ScoreP2;

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

        if ((TurnManager.turn % 2) == 0) {

            if (!isShocked) {
                moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }
            else {
                moveInput = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
            }
            moveAmount = moveInput.normalized * speed;
        }
        else {

            if (!isShocked) {
                moveInput = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
            }
            else {
                moveInput = new Vector2(Input.GetAxisRaw("Vertical2"), Input.GetAxisRaw("Horizontal2"));
            }
            moveAmount = moveInput.normalized * speed;



        }
        

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
            TurnManager.turn++;            
            Heal(3);
            Debug.Log(TurnManager.turn);
            Projectile.speed = 40;
            Shock.speed = 40;
            

            if ((TurnManager.turn % 2) == 0) {
                P1W++;
                ScoreP1.text= P1W.ToString();

            }
            else {
                P2W++;
                ScoreP2.text = P2W.ToString();
            }

            if (P1W == P2W) {
                Timer.end += 10;
            }

            if(P1W >= P2W) {
                P1Winning = true;
            }

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
