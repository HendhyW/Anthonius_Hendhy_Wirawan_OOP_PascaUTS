using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    public Transform parentTransform;
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 0.5f;

    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] public Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;
    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    
    private float timer;

    public Transform bulletSpawnPoint1;

    void Awake()
    {
        Assert.IsNotNull(bulletSpawnPoint);
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
        
    }

    //buat instance bullet 
    private Bullet CreateBullet()
    {
        Debug.Log("Create Bullet");
        Bullet bulletInstance = Instantiate(bullet);
        bulletInstance.objectPool = objectPool;
        bulletInstance.transform.parent = transform;
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
        Debug.Log(shootIntervalInSeconds);
        if(timer > shootIntervalInSeconds && objectPool != null){
            Bullet bulletObject = objectPool.Get();
        

            if(objectPool == null){
                return;
            }

            // bulletObject.transform.position = bulletSpawnPoint.position;
            bulletObject.transform.SetPositionAndRotation(bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            timer = 0f;
        }
        timer += Time.fixedDeltaTime;
    }
}