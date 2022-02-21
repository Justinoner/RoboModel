
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cam Speeds"), Tooltip("The speed the camera turns in degrees/second")]
    public float panSpeed = 20f;
    public float scrollSpeed = 20f;
    
    [Header("Border Limits"), Tooltip("stops the camera from moving past user defined points on the map")]
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    // Update is called once per frame
    void Update()
    {
        //Registers cam movement when a WASD key is pressed
        //Also registers movement when the courser is moved a certain amount
        Vector3 pos = transform.position;
        if (Input.GetKey("w")|| Input.mousePosition.y>= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= Screen.height - panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        ///
        /// Sets zoom input with scroll
        ///zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //scroll/zoom speed
        pos.y += scroll * scrollSpeed * 50f * Time.deltaTime;
        //scroll limits
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;
    }
}
