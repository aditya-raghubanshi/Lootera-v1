using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBars : MonoBehaviour
{
    // Start is called before the first frame update
    private Image bar;
    private CountdownScript ctdwn;
    void Start()
    {
        bar = GetComponent<Image>();
        ctdwn = FindObjectOfType<CountdownScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = ctdwn.getTimer() / ctdwn.getMaxTimer();
    }
}
