using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public  enum dropTypes { Random, Weighted, PercentWeighted };
    public dropTypes dropType;
    public RandomWeightedObject [] objectsToSpawn;
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
                spawnedObject = Instantiate(ChooseSpawnObject(), transform.position, transform.rotation) as GameObject;

                countdown = respawnTime;
            }

        }
    }

    public GameObject ChooseSpawnObject()
    {
        // var to hold spawn object
        GameObject objectToSpawn;

        // create a second parallel array - this holds the cutoffs (where it changes to the next type)
        //              Thus, anything below this cutoff is a parallel weighted object
        float[] CDFArray = new float[objectsToSpawn.Length];

        //var to hold cumalitive density (total of weights so far)
        float cumulativeDensity = 0;
        //fill CDF Array with cutoffs
        for (int i=0; i<objectsToSpawn.Length; i++)
        {
            //add this objects weight, so we know where the cutoff is
            cumulativeDensity += objectsToSpawn[i].weight;
            //Store that in the CDF Array
            CDFArray[i] = cumulativeDensity;
        }

        //choose a random number up to the max cutoff
        float rand = Random.Range(0.0f, cumulativeDensity);

        //look through my CDF to find where our random number would fall -- which CDF index would it fall under 
        /****Old one at a time method but it works
        for (int i=0; i<CDFArray.Length; i++)
        {
            if (rand < CDFArray[i])
            {
                objectToSpawn = objectsToSpawn[i].objectToSpawn;
                return objectToSpawn;
            }
        }
        *************/
        int selectedIndex = System.Array.BinarySearch(CDFArray, rand);

        //if selected index is neg
        if(selectedIndex < 0)
        {
            //it's not the exact value, we have to FLIP (bitwise not) the value to find te index we want
            selectedIndex = ~selectedIndex;
        }
        objectToSpawn = objectsToSpawn[selectedIndex].objectToSpawn;
        return objectToSpawn;
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
