using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    //Vitesse/vitesse max du joueur
    [SerializeField] private int Speed;
    [SerializeField] private int MaxSpeed;
    //Projectile
    [SerializeField] public GameObject Bullet;
    //Position du joueur
    public Vector2 PlayerPosition;
    //Orientation du joueur
    public Vector2 inputValue;
    //Orientation du tir
    public Vector2 ShootinputValue;

    public Player playerInput;
    private new Rigidbody rigidbody;

    //Activation des controles
    private void OnEnable()
    {
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Move.performed += Move;
        playerInput.Action.Move.canceled += Stop;
        playerInput.Action.Shoot.performed += Shoot;
    }

    //tir
    void Shoot(InputAction.CallbackContext obj)
    {
        ShootinputValue = obj.ReadValue<Vector2>();
        //Créer le projectile
        Instantiate(Bullet, PlayerPosition, Quaternion.identity);
    }
    //Déplacement
    private void Move(InputAction.CallbackContext obj)
    {
        inputValue = obj.ReadValue<Vector2>();

    }
    //Arret du déplacement
    private void Stop(InputAction.CallbackContext obj)
    {
        inputValue = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Garde la position du joueur dans une variable
        PlayerPosition = rigidbody.position;
        //Tant que le déplacement est inférieur à maxspeed, augmente la vitesse du joueur
        if (rigidbody.velocity.sqrMagnitude < MaxSpeed)
        {
            rigidbody.AddForce(inputValue * Speed);
        }
    }
}
