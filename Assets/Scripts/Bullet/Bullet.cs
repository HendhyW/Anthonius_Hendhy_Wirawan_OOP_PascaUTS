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

    [SerializeField] private float timeoutDelay = 3f;

    private IObjectPool<Bullet> objectPool;

    public IObjectPool<Bullet> ObjectPool
    {
        // get => objectPool;
        set => objectPool = value;
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(timeoutDelay));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectPool.Release(this);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // other.GetComponent<Enemy>().TakeDamage(damage);
            objectPool.Release(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (0f, bulletSpeed);
    }
}
