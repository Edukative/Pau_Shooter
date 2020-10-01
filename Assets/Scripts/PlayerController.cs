using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController player;

    public Vector3 direction = Vector3.zero;

    public float walkingSpeed;
    float runMultiplier;
    public float jumpForce;

    public float gravity = 9.81f;
    public float gravityForce;

    public bool isGrounded = false;

    public Camera myCamera;

    public float mouseXSensibility = 1.0f;
    public float mouseYSensibility = 1.0f;
    
    public bool inverty = false;

    public float topAngleY = 45.0f;
    public float botAngleY = -45.0f;

    private Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float mouse_x = Input.GetAxis("mose X") * mouseXSensibility * Time.fixedDeltaTime;
        float mouse_y = Input.GetAxis("mose Y") * mouseYSensibility * Time.fixedDeltaTime;

        mouse_y = Mathf.Clamp(mouse_y, botAngleY, topAngleY);

        mouse_y = inverty ? mouse_y * -1 : mouse_y * 1;

        if (inverty)
        {
            mouse_y = mouse_y * -1;
        }

        else
        {
            mouse_y = mouse_y * 1;
        }

        transform.Rotate(0, mouse_x, 0);
        myCamera.transform.Rotate(mouse_y, 0, 0);


        float dir_x = Input.GetAxis("Horitzontal");
        float dir_z = Input.GetAxis("Vertical");

        float rumMultiplier = (Input.GetAxis("Run") > 0) ? 2.0f : 1.0f;

        // press shift to run
        direction.x = dir_x * walkingSpeed * runMultiplier * Time.deltaTime;
        direction.z = dir_z * walkingSpeed * runMultiplier * Time.deltaTime;

        player.Move(direction);

        // press sace to jump
        if ((Input.GetAxis("Jump") > 0) && (isGrounded))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }

}
