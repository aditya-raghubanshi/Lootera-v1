using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRoot : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth health;
    float inithealth;
    Joystick joystick;
    GameObject player;
    public float radius = 3f;
    public float damage = 10f;

    // Update is called once per frame
    public void shieldRoot()
    {

        health = FindObjectOfType<PlayerHealth>();
        //print("shieldroot");
        health.setResistance(0.7f);
        inithealth = health.GetHealth();
        joystick = FindObjectOfType<Joystick>();
        joystick.gameObject.SetActive(false);
        StartCoroutine(ExecuteAfterTime(3));
        player = GameObject.Find("Player");

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Collider[] colliders = Physics.OverlapSphere(player.transform.transform.position, radius);
        float newhealth = health.GetHealth();
        foreach( Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(5000f, player.transform.transform.position, radius);

            }
            Dungeon_Monster_Controller monster = nearbyObject.GetComponent<Dungeon_Monster_Controller>();
            if(monster!= null)
            {
                monster.Damage(damage);
                print(monster.getHealth());
            }
            
        }

        joystick.gameObject.SetActive(true);
        health.setResistance(0f);

        
    }
}
