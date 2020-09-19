using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    //Appel du script control du joueur
    [SerializeField] public Control Player;
    //Orientation de la balle
    private Vector2 FixinputValue;
    private new Rigidbody rigidbody;
    public Player playerInput;

    // Start is called before the first frame update
    void Start()
    {
        //Limitation de l'orientation de la balle à la première valeure
        FixinputValue = Player.ShootinputValue;
        rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        playerInput = new Player();
        playerInput.Enable();
        playerInput.Action.Shoot.performed += Shoot;
    }

    void Shoot(InputAction.CallbackContext obj)
    {
        Player.ShootinputValue = obj.ReadValue<Vector2>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Déplacement de la balle
        rigidbody.AddForce(FixinputValue * 400);
    }
    void OnBecameInvisible()
    {
        //détruit la balle une fois hors de portée de la caméra
        Destroy(gameObject);
    }
}
