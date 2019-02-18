using UnityEngine;
using UnityEngine.AI;
public class Dungeon_Monster_Controller : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform goal;
    CharacterController controller;
    Animator anim;
    float attackRadius;
    float visibleRadius = 20;
    public int enemyHealth = 10;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        attackRadius = agent.stoppingDistance;
        print("Dungeon Monster in Start");
       
    }
    public void Update()
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
                Attack();
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
            
            Attack();
        }
        // if my health is 0; then die
      

    }
    void Walk(Vector3 PlayerPosition)
    {

        anim.SetBool("running", true);
        anim.SetInteger("condition", 1);
        anim.SetBool("attacking", false);
        agent.SetDestination(PlayerPosition);
        this.transform.LookAt(PlayerPosition);
        controller.Move(agent.desiredVelocity * Time.deltaTime);
    }
    void Attack()
    {
        print("Inside attack function");
        anim.SetBool("running", false);
        anim.SetInteger("condition", 2);
        anim.SetBool("attacking", true);
        controller.Move(Vector3.zero);
        agent.SetDestination(Vector3.zero);
    }
    void Idle()
    {
        anim.SetBool("running", false);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
        controller.Move(Vector3.zero);
        agent.SetDestination(Vector3.zero);
    }
 
    //}
}