using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public GameObject objectToSpawm;
    public float respawnTime;

    private float countdown;
    private GameObject spawnedObject;


    // Start is called before the first frame update
    void Start()
    {
        countdown = respawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedObject != null)
        {
            return;
        }

        else
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                spawnedObject = Instantiate(objectToSpawm, transform.position, transform.rotation);

                countdown = respawnTime;
            }

        }
    }
}
