using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Set itself as spawnpoint variable from gamemanager.
        GameManager.instance.PlayerSpawn = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
