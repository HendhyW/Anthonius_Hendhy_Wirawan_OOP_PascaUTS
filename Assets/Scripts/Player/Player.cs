using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] public HealthComponent healthComponent;

    PlayerMovement playerMovement;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("/Player/Engine/EngineEffect").GetComponent<Animator>();
    }


    void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
    else 
        { 
            Instance = this; 
        } 
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving",playerMovement.IsMoving());
    }   
}
