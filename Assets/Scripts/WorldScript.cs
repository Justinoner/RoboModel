using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private float StartTime;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SpawnPlayer();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
