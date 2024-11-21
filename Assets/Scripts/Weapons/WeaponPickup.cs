using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;

    Weapon weapon;
    
    Weapon currentWp;

    SpriteRenderer wpSprite;
    void Awake()
    {
        weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
        wpSprite = weapon.GetComponentInChildren<SpriteRenderer>();
        TurnVisual(false);
        
    }
    
    //method start tidak langsung dijalankan, gatau kenapa
    void Start()
    {
        if (!weapon){
            //buat weapon invisible sebelum terjadi colide
            Debug.Log("jalan");
            TurnVisual(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentWp = other.GetComponentInChildren<Weapon>();
        if (other.CompareTag("Player"))
        {
            if(currentWp){
                //cek apakah saat ini ada weapon atau tidak
                if(currentWp != weapon){
                    TurnVisual(false, currentWp);
                    weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
                }
            }

            weapon.transform.SetParent(other.transform);
            //ubah posisi relatif weapon ke player
            weapon.transform.localPosition = new Vector3(0f,0.1f,2f);
            TurnVisual(true, weapon);
        }
    }

    // Update is called once per frame
    void TurnVisual(bool on)
    {
        wpSprite.enabled = on;
    }

    void TurnVisual(bool on, Weapon weapon)
    {   
        wpSprite = weapon.GetComponentInChildren<SpriteRenderer>();
        wpSprite.enabled = on;
        if(!on){
            Destroy(weapon.gameObject);
            // weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
            // TurnVisual(false);
        }
    }

}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeaponPickup : MonoBehaviour
// {
//     [SerializeField] Weapon weaponHolder;

//     Weapon weapon;
    
//     Weapon currentWp;

//     SpriteRenderer wpSprite;
//     void Awake()
//     {
//         weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
//         wpSprite = weapon.GetComponentInChildren<SpriteRenderer>();
//         TurnVisual(false);
//         weapon.bulletSpawnPoint1 = Instantiate(weapon.bulletSpawnPoint, weapon.transform);
//     }
    
//     //method start tidak langsung dijalankan, gatau kenapa
//     void Start()
//     {
//         if (!weapon){
//             //buat weapon invisible sebelum terjadi colide
//             Debug.Log("jalan");
//             TurnVisual(false);
//         }
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         currentWp = other.GetComponentInChildren<Weapon>();
//         if (other.CompareTag("Player"))
//         {
//             if(currentWp){
//                 //cek apakah saat ini ada weapon atau tidak
//                 if(currentWp != weapon){
//                     TurnVisual(false, currentWp);
//                     weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
//                 }
//             }

//             weapon.transform.SetParent(other.transform);
//             //ubah posisi relatif weapon ke player
//             weapon.transform.localPosition = new Vector3(0f,0.1f,2f);
//             TurnVisual(true, weapon);
//         }
//     }

//     // Update is called once per frame
//     void TurnVisual(bool on)
//     {
//         wpSprite.enabled = on;
//     }

//     void TurnVisual(bool on, Weapon weapon)
//     {   
//         wpSprite = weapon.GetComponentInChildren<SpriteRenderer>();
//         wpSprite.enabled = on;
//         if(!on){
//             Destroy(weapon.gameObject);
//             // weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
//             // TurnVisual(false);
//         }
//     }

// }