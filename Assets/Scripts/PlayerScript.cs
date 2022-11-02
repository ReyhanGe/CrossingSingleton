using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpForce;

    private float vertical, horizontal;

    public Transform groundCheck;

    private Rigidbody rigidBody;
    private float groundDistances;
    public LayerMask layerMask;

    private bool isGrounded;

    public float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        groundDistances = 0.4f;
        rigidBody = GetComponent<Rigidbody>();                
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime ;  

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistances, layerMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce);
        }

        if(health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(horizontal, 0 , vertical);
    }

    
}
