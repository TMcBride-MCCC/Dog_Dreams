using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    private float currTime;
    private TMP_Text guiTimeText;
    // Start is called before the first frame update
    void Start()
    {
        guiTimeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        guiTimeText.text = "Time: " + currTime.ToString("F1");
    }
}
