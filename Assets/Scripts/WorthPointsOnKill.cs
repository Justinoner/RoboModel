using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorthPointsOnKill : MonoBehaviour
{
    public float pointValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        //Add points to our game score
        Debug.Log("You scored points: " + pointValue);
    }
}
