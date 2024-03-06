using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 30;
    public float speed = 4.5f;
    public GameObject target;
    public bool isDead => hp <= 0;
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
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
}
