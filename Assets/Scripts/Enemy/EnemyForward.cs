using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
{
    Rigidbody2D rb;
    private float yspeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomize();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -yspeed);
        if(rb.position.y <= -5){
            rb.position = new Vector2(rb.position.x, 5);
        }
    }

    void randomize()
    {
        rb.position = new Vector2(Random.Range(-8, 8), 5);
    }
}
