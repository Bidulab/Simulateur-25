using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bean : MonoBehaviour
{
    public GameObject monRobot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = monRobot.transform.position + new Vector3(0, 1, 0);
    }
}
