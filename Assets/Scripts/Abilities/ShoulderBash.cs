using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderBash : MonoBehaviour
{
    private GameObject player;
    private Joystick joystick;
    public float movSpeed = 50f;


    public void Move()
    {
        player = GameObject.Find("Player");
        joystick = FindObjectOfType<Joystick>();
        for( int i =1; i <=10; i++)
        {
            Vector3 movement = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
            player.transform.Translate(movement * movSpeed * Time.deltaTime, Space.World);
        }
        
    }
}
