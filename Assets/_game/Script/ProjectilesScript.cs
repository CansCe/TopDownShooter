using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ProjectilesScript : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float existanceTime = 2f;
    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }
    void Update()
    {
        if(existanceTime <= 0)
        {
            gameObject.SetActive(false);
            existanceTime = 2f;
        }
        else
        {
            existanceTime -= Time.deltaTime;
        }
    }
}
