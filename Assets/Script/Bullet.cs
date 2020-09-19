using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Orientation de la balle
    public Vector2 fixinputValue;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Limitation de l'orientation de la balle 
        rigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Déplacement de la balle
        rigidbody.AddForce(fixinputValue * 400);
    }
    void OnBecameInvisible()
    {
        //détruit la balle une fois hors de portée de la caméra
        Destroy(gameObject);
    }
}
