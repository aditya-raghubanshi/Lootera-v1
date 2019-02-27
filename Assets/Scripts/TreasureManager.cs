using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TreasureManager : MonoBehaviour
{
    [SerializeField]  public GameObject[] weapons;                // The weapon prefab to be spawned.
    [SerializeField] public GameObject[] weaponObjects;                // The weapon objects spawned.
    private Vector3[] weaponPositions;
    [SerializeField]  public float spawnTime = 4f;            // How long between each spawn.
    [SerializeField]  public float SpawnRadius = 5000;
    [SerializeField]  public int spawnNumber = 4;
    static int weaponIndex = 0;

    public static List<WeaponSaveData> inventory = new List<WeaponSaveData>();
    
    protected GameObject player;
    //public Transform interactionTransform;

    void Start()
    {
        LoadSerializedWeapons();
        player = GameObject.Find("Player");
        //interactionTransform = this.transform;

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        weaponPositions = new Vector3[weapons.Length];
        weaponObjects = new GameObject[weapons.Length];
        for (int i = 0; i < spawnNumber; i++)
        {
            Spawn();
        }

    }

    public void PickTreasure()
    {
        Debug.Log("INTERACTION PRESSED!");
        for (int i = 0; i < weaponPositions.Length; i++)
        {

            Debug.Log("LOOPING....");
            float distance = Vector3.Distance(player.transform.transform.position, weaponPositions[i]);
            if (distance <= 3f)
            {
                Interact(i);
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    public void Interact(int weaponIndex)
    {
        Debug.Log("Interacting with Treausre");
        inventory.Add(new WeaponSaveData(weapons[weaponIndex].ToString()));
        Destroy(weaponObjects[weaponIndex]);

        SaveSerializedWeapons();
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        //int weaponIndex = Random.Range(0, weapons.Length);
        Quaternion rot = GameObject.Find("Player").transform.rotation;
        rot.y = System.Math.Abs(360 - rot.y);

        // Create an instance of the weapon prefab at the randomly selected spawn point's position and rotation.
        Debug.Log("index:" + weaponIndex);
        weaponPositions[weaponIndex] = RandomNavmeshLocation(SpawnRadius);
        weaponObjects[weaponIndex] = Instantiate(weapons[weaponIndex], weaponPositions[weaponIndex], rot);
        weaponIndex++;
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        while (true)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius * (weaponIndex + 2);
            //randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
                finalPosition.y = 2;
                return finalPosition;
            }
        }
    }

    public void SaveSerializedWeapons()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/treasureWeaponInfo.dat";
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(serializedWeaponFileName))
        {
            File.Delete(serializedWeaponFileName);
        }
        FileStream file = File.Create(serializedWeaponFileName);
        bf.Serialize(file, inventory);
        file.Close();
    }

    private void LoadSerializedWeapons()
    {
        string serializedWeaponFileName = Application.persistentDataPath + "/treasureWeaponInfo.dat";
        if (File.Exists(serializedWeaponFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(serializedWeaponFileName, FileMode.Open);
           if (fileStream.Length != 0)
            {
                inventory = (List<WeaponSaveData>)bf.Deserialize(fileStream);
            }
            
            fileStream.Close();
        }
        else
        {
            Debug.Log("Loading Data failed. File " + serializedWeaponFileName + "doesn't exist");
        }
    }

    [System.Serializable]
    public struct WeaponSaveData
    {
        public string name;

        public WeaponSaveData(string name)
        {
            this.name = name.ToString();
        }
    };
}
