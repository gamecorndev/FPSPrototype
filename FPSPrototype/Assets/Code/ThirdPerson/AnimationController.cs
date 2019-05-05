using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    FpsController controller;
    PlayerLook look;
    Animator anim;

    // IK
    [Header("IKs Targets")]
    public Transform LookAtTarget;
    public Transform LookAtTargetLeft;
    public Transform LookAtTargetRight;
    public Vector3 Offset;

    // bone to rotate
    Transform Chest;
    public float ClamRotationAim = 2f;
    public float RotationSpeed = 3f;
    public float StoredX;
    public Vector3 angleDirect;
    public bool Jumping;
    // check Right movement

    public float lastPosition;
    bool aim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        look = gameObject.GetComponentInChildren<PlayerLook>();
        controller = GetComponent<FpsController>();

        // IK setup
        // name of bone to setup with ik
        Chest = anim.GetBoneTransform(HumanBodyBones.Chest);
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Jumping == true)
            return;
        
        SetAnimations();
     
    }


  // enables player to look in a direction
    private void LateUpdate()
    {


        if (Jumping == true)
            return;

      //  Chest.LookAt(LookAtTarget);
        if(look.mouseX > 0)
        {
            StoredX += 1.5f;
          
            if (StoredX >= ClamRotationAim)
                StoredX = ClamRotationAim;
        }
        if (look.mouseX < 0)
        {
            StoredX -= 1.5f;
            // Mathf.Clamp(StoredX, -ClamRotationAim, ClamRotationAim);
            if (StoredX < -ClamRotationAim)
                StoredX = -ClamRotationAim;
        }
        // aim
       // Vector3 Direct = new Vector3(0,StoredX *RotationSpeed , 0);
      //  Chest.rotation = Chest.rotation * Quaternion.Euler(Direct);
        
    }
    public void SetAnimations()
    {

        // Turn Without moveing
        if (look.mouseX != 0 && controller.vertInput == 0 && controller.horizInput == 0)
        {
            if(anim.GetBool("Turning") == false)
             {
             anim.SetBool("Turning", true);
              }

              anim.SetFloat("TurnDirection", look.mouseX);
        //    Vector3 TurnAngle = new Vector3(0, look.mouseX  *6f, 0);
         //   Chest.rotation = Chest.rotation * Quaternion.Euler(TurnAngle);
           // anim.SetFloat("TurnDirection", look.mouseX);
        }
        // move
        else
        {
            if (anim.GetBool("Turning") == true)
            {
                anim.SetBool("Turning", false);
            }
          
            anim.SetFloat("Forward", look.mouseX);
            float forward = controller.vertInput;
            anim.SetFloat("Forward", forward);

            // float sideways = controller.horizInput;
            float sideways = controller.horizInput;
            anim.SetFloat("Sideways", sideways);

        }
        bool aim = look.AimingIsTrue;
       anim.SetBool("Aim", aim);
    }

    public void PlayJumpAnimation()
    {
        Jumping = true;
        anim.SetBool("Jumping", true);
        Debug.Log("PlayedJumpAnimation");
    }

    public void StopJumpingAnimation()
    {
        Jumping = false;
        anim.SetBool("Jumping", false);
        Debug.Log("ExitedJumpAnimation");
    }
  
    public void PlayReloadAnimation()
    {
        anim.SetBool("Reloading", true);
    }
    public void StopReloadAnimation()
    {
        anim.SetBool("Reloading", false);
    }
}
