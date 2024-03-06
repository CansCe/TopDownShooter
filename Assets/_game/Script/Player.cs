using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead => hp <= 0;
    public float speed = 5.0f;
    public int hp = 5;
    public Joystick controller;
    public Animator anim;
    public static Player instance;
    public GameObject gunHolder;
    public GameObject enemy;
    public Rigidbody2D rb;
    [SerializeField] string currentAnim="";
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if(controller == null)
        {
            controller = GameObject.FindAnyObjectByType<Joystick>();
        }
        Vector2 input = new Vector2(controller.Horizontal, controller.Vertical);
        if(input != Vector2.zero && !isDead)
        {
            //if player moving to the left side, flip the player
            if(input.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(input.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            ChangeAnim("Run");
            transform.Translate(input * speed * Time.deltaTime);
        }
        else
        {
            if (!isDead)
                ChangeAnim("Idle");
        }
    }
    public void FindNearestEnemy()
    {
        //find any gameobject with tag enemy and get the nearest one
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                this.enemy = enemy;
                distance = curDistance;
            }
        }
    }
    //add to update if player use gun
    public void RotateGunHolder(GameObject enemy)
    {
        if(enemy != null)
        {
            if(enemy.transform.position.x < gunHolder.transform.position.x)
            {
                gunHolder.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                gunHolder.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Vector3 direction = enemy.transform.position - gunHolder.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gunHolder.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void Hit()
    {
        //push player back a bit
        if(hp ==1)
        {
            Dead();
        }
        rb.AddForce(new Vector2(-transform.localScale.x, 1) * 5, ForceMode2D.Impulse);
        hp--;
        rb.velocity = Vector2.zero;
    }
    public void Dead()
    {
        hp =0;
        ChangeAnim("Dead");
    }
    public void ChangeAnim(string newAnim)
    {
        if(currentAnim != "")
        {
            if(currentAnim.CompareTo(newAnim)!=0)
                anim.ResetTrigger(currentAnim);
        }
        currentAnim = newAnim;
        anim.SetTrigger(currentAnim);
    }
}
