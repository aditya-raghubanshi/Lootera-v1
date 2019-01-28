using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    protected Joystick joystick;
    public float movSpeed = 14f;
    float horizontalMovement = 0f;
    float verticalMovement = 0f;
    public float sens = 0.2f;
    public float rotsens = 0.08f;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        var animate = GetComponent<Animator>();
        rigidbody.freezeRotation = true;
        if (joystick.Horizontal > sens)
            horizontalMovement = 1f;
        else if (joystick.Horizontal < -sens)
            horizontalMovement = -1f;
        else
            horizontalMovement = 0f;


        if (joystick.Vertical > sens)
            verticalMovement = 1f;
        else if (joystick.Vertical < -sens)
            verticalMovement = -1f;
        else
            verticalMovement = 0f;

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotsens);
        transform.Translate(movement * movSpeed * Time.deltaTime, Space.World);
        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            animate.SetFloat("Forward", 1f, 0f, Time.deltaTime);
            //animate.SetFloat("Turn", 1f, 0f, Time.deltaTime);
        }
            
        else
            animate.SetFloat("Forward", 0f, 0f, Time.deltaTime);
        
        if (transform.position.y < -20f)
        {
            transform.position = new Vector3(64f, 5f, 3f);
        }
        //rigidbody.velocity = new Vector3(horizontalMovement * movSpeed * Time.deltaTime, rigidbody.velocity.y, verticalMovement * movSpeed * Time.deltaTime);

    }

}
