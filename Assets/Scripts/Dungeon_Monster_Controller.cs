using UnityEngine;
using UnityEngine.AI;
using System.Collections;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class Dungeon_Monster_Controller : MonoBehaviour
{
    
    public NavMeshAgent agent;
    CharacterController controller;
    Animator anim;
    float attackRadius;
    public float visibleRadius = 20;
    public int enemyHealth = 10;
    private PlayerHealth health;

    public NavMeshAgent Agent { get => agent; set => agent = value; }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        attackRadius = Agent.stoppingDistance;
        print("Dungeon Monster in Start");
        health = FindObjectOfType<PlayerHealth>();
       
    }
    public void FixedUpdate()
    {
        Vector3 PlayerPosition = GameObject.Find("Player").transform.position;
        float dist = Vector3.Distance(transform.position, PlayerPosition);
        print("distance " + dist);
        // When are we walking? - when we can see him and we are not attacking;
        if(dist<visibleRadius)
        {
            print("Inside Visible Radius");
            // when to stop walking when we are walking.
            // if we are in attack radius 
            if(dist<attackRadius)
            {
                print("Inside Attack");
                Attack(PlayerPosition);
            }
            // if he is out of visible radius. 
            else if(dist>visibleRadius)
            {
                Idle();
            }
            else
            {
                Walk(PlayerPosition);
            }
            
        }
        // When to become Idle - don`t really care which state we are in, if he is out of range just stop.

        if(dist>visibleRadius)
        {
            Idle();
        }

        // When to Attack
        if (dist<attackRadius)
        {
            
            Attack(PlayerPosition);
            
            //health.Damage(10);
        }
        // if my health is 0; then die
      

    }
    void Walk(Vector3 PlayerPosition)
    {

        this.transform.LookAt(PlayerPosition);
        anim.SetBool("running", true);
        anim.SetInteger("condition", 1);
        anim.SetBool("attacking", false);
        Agent.SetDestination(PlayerPosition);
        controller.Move(Agent.desiredVelocity * Time.deltaTime);
    }
    void Attack(Vector3 PlayerPosition)
    {
        this.transform.LookAt(PlayerPosition);
        print("Inside attack function");
        anim.SetBool("running", false);
        anim.SetInteger("condition", 2);
        anim.SetBool("attacking", true);
        
        controller.Move(Vector3.zero);
        Agent.SetDestination(Vector3.zero);
        
    }
    void Idle()
    {
        anim.SetBool("running", false);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
        controller.Move(Vector3.zero);
        Agent.SetDestination(Vector3.zero);
    }
 
    //}
}