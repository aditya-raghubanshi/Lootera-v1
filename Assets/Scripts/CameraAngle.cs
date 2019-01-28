using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    public float cameraDistOffsetx = 0f;
    public float cameraDistOffsety = -30f;
    public float cameraDistOffsetz = 60f;
    public float rotX = 30f;
    public float rotY = 0f;
    public float rotZ = 0f;

    private Camera mainCamera;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x - cameraDistOffsetx, playerInfo.y - cameraDistOffsety, playerInfo.z - cameraDistOffsetz);
    }*/
    private void LateUpdate()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
        mainCamera.transform.position = new Vector3(playerInfo.x - cameraDistOffsetx, playerInfo.y - cameraDistOffsety, playerInfo.z - cameraDistOffsetz);
    }
}
