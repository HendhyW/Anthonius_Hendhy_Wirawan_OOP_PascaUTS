using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    private Transform player;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
