
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Pawn player;
    private Vector3 offset;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    [Header("Cam Speeds"), Tooltip("The speed the camera turns in degrees/second")]
   
    public float scrollSpeed = 20f;
    
   
   

    // Update is called once per frame
    void Start()
    {
        if (player == null) 
        {
            Debug.LogWarning("Character not connected");
        }
        else
        {
            offset = transform.position - player.transform.position;
        }

        
    }
    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player doesn't exist");
        }
        else
        {
            Vector3 newPos = player.transform.position + offset;

            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        }



    }
}
