using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public GameObject objectToSpawm;
    public float respawnTime;
    public Mesh spawnMesh;

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
                spawnedObject = Instantiate(objectToSpawm, transform.position, transform.rotation) as GameObject;

                countdown = respawnTime;
            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        

        Matrix4x4 MyNewCoordinateSystem = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.Lerp(Color.black, Color.clear, 0.7f);
        Gizmos.matrix = MyNewCoordinateSystem;
        Gizmos.DrawMesh(spawnMesh, new Vector3(0, 0, 0), Quaternion.identity);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward);
    }
}
