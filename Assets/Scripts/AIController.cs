using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Awake();

    public abstract void Start();


    // Update is called once per frame
    public abstract void Update();
   
}
