using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{

    [SerializeField]
    Vector3 cameraOffset;
    [SerializeField]
    float damping;

   public Transform cameraLookTarget;
   public Transform localPlayer;

    // new Stuff variables
    public float mouseX;
    public float mouseY;
    public string mouseXInputName = "Mouse X";
    public string mouseYInputName = "Mouse Y";
    public float mouseSensitiveity;
    public bool Aiming;
    public float StoredY;
    private float xAxisClamp;

    public bool lockCursor;
    private Vector3 offset;


    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }



    private void Update()
    {
        CameraRotation();
    }
    void LateUpdate()
    {
        mouseY = Input.GetAxisRaw(mouseYInputName) * mouseSensitiveity;

        if (mouseY > 0)
            Aiming = true;
        else if (mouseY < 0)
            Aiming = true;
        else
            Aiming = false;


      
            Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
           localPlayer.transform.up * cameraOffset.y + localPlayer.transform.right * cameraOffset.x;

            Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

            transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);


            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
        
        
    }



    // new stuff hand mouse looking

    private void CameraRotation()
    {
        //  float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitiveity * Time.deltaTime;
        //  float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitiveity * Time.deltaTime;

        //ALTERD
        mouseX = Input.GetAxisRaw(mouseXInputName) * mouseSensitiveity;
        mouseY = Input.GetAxisRaw(mouseYInputName) * mouseSensitiveity;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

    
      
         transform.Rotate(Vector3.left * mouseY);
    
        localPlayer.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;

    }
}
