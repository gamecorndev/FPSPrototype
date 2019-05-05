using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    public float smoothSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {

       
        //  gameObject.transform =
        Vector3 desiredPositionn = Target.position + offset; ;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPositionn, smoothSpeed);
        transform.position = smoothedPosition;
         transform.LookAt(Target);
    }
}
