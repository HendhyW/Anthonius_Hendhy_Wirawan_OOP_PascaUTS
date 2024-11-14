using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    public Transform parentTransform;
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;

    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;
    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    private float timer;

    void Awake()
    {
        Debug.Log("Awake Weapon");
        bullet = GetComponent<Bullet>();
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
    }

    //buat instance bullet 
    private Bullet CreateBullet()
    {
        Debug.Log("Create Bullet");
        Bullet bulletInstance = Instantiate(bullet);
        bulletInstance.ObjectPool = objectPool;
        return bulletInstance;
    }

    //ketika ambil bullet dari pool
    private void OnGetFromPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    //ketika menaruh kembali bullet ke pool
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }   

    //ketika jumlah bullet lebih dari maxsize
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    private void FixedUpdate()
    {
        // Debug.Log(timer);
        // if(timer > shootIntervalInSeconds && objectPool != null){
        //     Bullet bulletObject = objectPool.Get();

        //     if(objectPool == null){
        //         return;
        //     }

        //     // bulletObject.transform.position = bulletSpawnPoint.position;
        //     bulletObject.transform.SetPositionAndRotation(bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        //     timer = 0f;
        // }
        // timer += Time.fixedDeltaTime;
    }
}