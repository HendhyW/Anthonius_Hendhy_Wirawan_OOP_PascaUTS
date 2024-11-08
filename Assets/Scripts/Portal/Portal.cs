using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;

    Vector2 newPosition;

    Rigidbody2D rb;

    SpriteRenderer sp;

    Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        sp.enabled = false;
        col.enabled = false;
        rb.angularVelocity = rotateSpeed;
        rb.velocity = new Vector2(0.2f * Random.Range(-1.0f, 1.0f) * speed, 0.2f * Random.Range(-1.0f, 1.0f) * speed);
        
        ChangePosition();
    }


    void Update()
    {
        if(GameObject.Find("/Player").GetComponentInChildren<Weapon>() != null)
        {
            sp.enabled = true;
            col.enabled = true;
        }
        if(Mathf.Abs(rb.position.x - newPosition.x) < 0.5f || Mathf.Abs(rb.position.y - newPosition.y) < 0.5f)
        {
            ChangePosition();
        }
        Mathf.Clamp(rb.position.x, -6.0f, 6.0f);
        Mathf.Clamp(rb.position.y, -3.0f, 3.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.levelManager.LoadScene("Main");
        }
    }

    void ChangePosition()
    {
        newPosition = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
    }
}