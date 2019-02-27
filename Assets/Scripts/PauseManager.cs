using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
