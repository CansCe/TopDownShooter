using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 30;
    public float speed = 4.5f;
    public GameObject target, explosionPrefab;
    public Animator anim;
    public bool isDead => hp <= 0;
    [SerializeField] string currentAnim ="";
    public List<Component> skillList = new List<Component>();
    public void Start()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }
    public void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        if(target != null)
        {
            ChangeAnim("fly");
            if(target.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void SpawnExplosion()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }    


    public void Die()
    {
        Destroy(gameObject);
        SpawnExplosion();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Invoke("Die", 1f);
        }
    }

    public void ChangeAnim(String newAnim)
    {
        if(currentAnim != newAnim)
        {
            if(currentAnim != "")
                anim.ResetTrigger(currentAnim);
        }
        currentAnim = newAnim;
        anim.SetTrigger(currentAnim);
    }
    public void TriggerWhenDie()
    {

    }
    public void TriggerWhenLive()
    {

    }
}
