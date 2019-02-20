using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    public GameObject [] enemies;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public float SpawnRadius = 10;
    public int spawnNumber = 10;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        
        // InvokeRepeating("Spawn", spawnTime, spawnTime);

        for(int i = 0;i<spawnNumber;i++)
        {
            Spawn();
        }

    }


    void Spawn()
    {
        // If the player has no health left...

        // Find a random index between zero and one less than the number of spawn points.
        int enemyIndex = Random.Range(0, enemies.Length);
        Quaternion rot = GameObject.Find("Player").transform.rotation;
        rot.y = System.Math.Abs(360 - rot.y);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemies[enemyIndex], RandomNavmeshLocation(SpawnRadius),rot );
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        while (true)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
                return finalPosition;
            }
        }

        
    }
}