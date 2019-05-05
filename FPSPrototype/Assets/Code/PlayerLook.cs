using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    [SerializeField]
    private string mouseXInputName, mouseYInputName;
    [SerializeField]
    private float mouseSensitiveity;

    [SerializeField]
    private Transform playerBody;

    private float xAxisClamp;

    private FpsController controller;
   public Animator anim;

    // mouse input
    public float mouseY;
    public float mouseX;
    // handles the aim,run,backup zoom in 
    // and out of camera
    [Header("CamLerp")]
    public Transform Target;
    public float smoothSpeed = 0.125f;
    public Transform AimOffset;
    public Transform RunOffset;
    public Transform idleOffset;
    public Transform BackUpOffset;
    public Transform walkOffset;
    public Transform LeftOffset;
    public Transform RightOffset;
    public Transform JumpOffset;
    bool switchCamPosition;
    public bool AimingIsTrue;
    public float StoreX;
    // bool check
    public enum CamStates
    {
        aiming,
        idleing,
        running,
        backingUp,
        moveLeft,
        moveRight,
        jump
    }

    public CamStates camState;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
     
    }
    // Use this for initialization
    void Start () {
        // playerBody = gameObject.GetComponentInParent<Transform>();
          controller = gameObject.GetComponentInParent<FpsController>();
        // anim = gameObject.GetComponentInParent<PlayerMovement>().Animator;
      //  anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        CameraRotation();
	}

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
      //  float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitiveity * Time.deltaTime;
      //  float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitiveity * Time.deltaTime;

        //ALTERD
         mouseX = Input.GetAxisRaw(mouseXInputName) * mouseSensitiveity ;
         mouseY = Input.GetAxisRaw(mouseYInputName) * mouseSensitiveity ;

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
        playerBody.Rotate(Vector3.up * mouseX);


     
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;

    }


    private void LateUpdate()
    {

      HandleCamMovement();
    }


    public void HandleCamMovement()
    {

        // if is idle
        if (controller.isJumping == true  && camState != CamStates.aiming)
        {
            camState = CamStates.jump;
            
        }
        else if(camState != CamStates.aiming)
        {
            camState = CamStates.idleing;
        }

        
        // if is idle
        if (controller.horizInput > 0 && controller.vertInput == 0 && camState != CamStates.aiming && camState != CamStates.jump)
        {
            camState = CamStates.moveRight;
        }

        // if is idle
        if (controller.horizInput < 0 && controller.vertInput == 0 && camState != CamStates.aiming && camState != CamStates.jump)
        {
            camState = CamStates.moveLeft;
        }

        // if is idle
        if (controller.horizInput == 0 && controller.vertInput == 0 && camState != CamStates.aiming && camState != CamStates.jump)
        {
            camState = CamStates.idleing;
        }
        // if is moveing foward
        if (controller.vertInput > 0 && camState != CamStates.aiming && camState != CamStates.jump)
        {
            camState = CamStates.running;
        }

        // if is moveing backward
        if (controller.vertInput < 0 && camState != CamStates.aiming && camState != CamStates.jump)
        {
            camState = CamStates.backingUp;
        }

        // if is aiming
        if (Input.GetKeyDown(KeyCode.Q))
        {
            camState = CamStates.aiming;
            AimingIsTrue = true;
        }

        // if has stoped aiming
        if (Input.GetKeyUp(KeyCode.Q))
        {
            camState = CamStates.idleing;
            AimingIsTrue = false;
        }

        if (camState == CamStates.jump)
        {
            Jump();
        }
        // if is idle
        if (camState == CamStates.idleing )
        {
            Idleing();
        }

        if (camState == CamStates.running)
        {
            Run();
        }

        if (camState == CamStates.backingUp)
        {
            BackUp();
        }

        if (camState == CamStates.aiming)
        {
            Aim();
        }
        if (camState == CamStates.moveLeft)
        {
            MoveLeft();
        }
        if (camState == CamStates.moveRight)
        {
            MoveRight();
        }

    }
    // handleing zooming in and out of camera
    public void Aim()
    {
     //  Vector3 desiredPositionn = Target.localPosition + AimOffset;
      Vector3 desiredPositionn =  AimOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
        
    }

    public void Run()
    {
     // Vector3 desiredPositionn = Target.localPosition + RunOffset;
        Vector3 desiredPositionn =  RunOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }
    public void BackUp()
    {
    //   Vector3 desiredPositionn = Target.localPosition + BackUpOffset;
      Vector3 desiredPositionn =  BackUpOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }
    public void Idleing()
    {
     //  Vector3 desiredPositionn = Target.localPosition + idleOffset;
       Vector3 desiredPositionn =  idleOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }

    public void MoveRight()
    {
        //  Vector3 desiredPositionn = Target.localPosition + idleOffset;
        Vector3 desiredPositionn = RightOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }

    public void MoveLeft()
    {
        //  Vector3 desiredPositionn = Target.localPosition + idleOffset;
        Vector3 desiredPositionn = LeftOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }

    public void Jump()
    {
        //  Vector3 desiredPositionn = Target.localPosition + idleOffset;
        Vector3 desiredPositionn = JumpOffset.localPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.localPosition, desiredPositionn, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }

}
