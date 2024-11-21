using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;
    private Rigidbody2D rb;

    [SerializeField] private float timeoutDelay = 0.5f;

    public IObjectPool<Bullet> objectPool;

    // public IObjectPool<Bullet> ObjectPool
    // {
    //     // get => objectPool;
    //     set => objectPool = value;
    // }

    // public void Deactivate()
    // {
    //     StartCoroutine(DeactivateRoutine(timeoutDelay));
    // }

    // IEnumerator DeactivateRoutine(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     objectPool.Release(this);
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HitboxComponent>().Damage(this);
            objectPool.Release(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (0f, bulletSpeed);
    }

    private void Update()
    {
        Vector2 ppos = Camera.main.WorldToViewportPoint(transform.position);

        if (ppos.y >= 1.01f || ppos.y <= -0.01f && objectPool != null)
        {
            // objectPool.Release(this);
        }
    }
}

// using System;
// using UnityEngine;
// using UnityEngine.Assertions;
// using UnityEngine.Pool;

// public class Bullet : MonoBehaviour
// {
//     [Header("Bullet Stats")]
//     public float bulletSpeed = 20;
//     public int damage = 10;

//     private Rigidbody2D rb;

//     public IObjectPool<Bullet> objectPool;

//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     private void FixedUpdate()
//     {
//         rb.velocity = bulletSpeed * Time.deltaTime * transform.up;
//     }

//     private void Update()
//     {
//         Vector2 ppos = Camera.main.WorldToViewportPoint(transform.position);

//         if (ppos.y >= 1.01f || ppos.y <= -0.01f && objectPool != null)
//         {
//             objectPool.Release(this);
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Enemy"))
//         {
//             other.gameObject.GetComponent<HitboxComponent>().Damage(this);
//             objectPool.Release(this);
//         }
//     }
// }
