using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    //Vitesse/vitesse max du joueur
    [SerializeField] private int speed;
    [SerializeField] private int maxSpeed;
    //Projectile
    [SerializeField] private GameObject bulletPrefab;
    //Orientation du joueur
    private Vector2 inputValue;

    private Player playerInput;
    private Rigidbody rigidbody;

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
        //Orientation du tir
        var shootinputValue = obj.ReadValue<Vector2>();
        //Créer le projectile
        var createBullet = Instantiate(bulletPrefab, rigidbody.position, Quaternion.identity);
        createBullet.GetComponent<Bullet>().FixinputValue = shootinputValue;
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
        //Tant que le déplacement est inférieur à maxspeed, augmente la vitesse du joueur
        if (rigidbody.velocity.sqrMagnitude < maxSpeed)
        {
            rigidbody.AddForce(inputValue * speed);
        }
    }
}
