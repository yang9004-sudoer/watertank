using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;


    float velocity = 1.0f;
    Vector3 rot_v = new Vector3(0,1.0f,0);

    float smooth = 5.0f;
    float tiltAngle = 60.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    {
        
        
        // WASD key control
        if(Input.GetKey(KeyCode.W)){
            Debug.Log("Capture W key");
            transform.position += velocity * Time.fixedDeltaTime * transform.forward;
        }

        if(Input.GetKey(KeyCode.S)){
            Debug.Log("Capture S Key");
            transform.position += velocity * Time.fixedDeltaTime * transform.forward * -1;
        }
        if (axes == RotationAxes.MouseXAndY)
        {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

//         if (Input.GetKey(KeyCode.A)){
//             float tiltAroundY = 1.0f * Time.fixedDeltaTime;
//             Quaternion target = Quaternion.Euler(0, 1, 0);
//             transform.rotation +=             target ;
// ; 
//         }

//         if (Input.GetKey(KeyCode.D)){
            
//         }

        // Smoothly tilts a transform towards a target rotation.
        // float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // // Dampen towards the target rotation
        // transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
    }
}
// 