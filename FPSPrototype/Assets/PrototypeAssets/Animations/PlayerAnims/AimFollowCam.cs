using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFollowCam : MonoBehaviour
{

  public  Transform FollowTarget;
   
    public Vector3 OffsetX;
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
          Vector3 newOffset = new Vector3(FollowTarget.position.x + OffsetX.x, FollowTarget.position.y + OffsetX.y, FollowTarget.position.z + OffsetX.z);
        transform.position = newOffset;
        transform.rotation = FollowTarget.localRotation;

    }
}
