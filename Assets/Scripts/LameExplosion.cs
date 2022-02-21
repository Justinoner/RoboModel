using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LameExplosion : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Debug.Log("La Bomba!"+ name);
    }

    public void ExplodeAtPoint(Transform point)
    {
        Debug.Log("La Bomba!" + name);
    }
}
