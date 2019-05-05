using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController CharacterController;
   public Animator Animator;

    [SerializeField]
    public float moveSpeed = 7.5f;
    [SerializeField]
    public float turnSpeed = 150f;

   public string HorizontalInput = "Horizontal";
    public string VerticalInput = "Vertical";
    public string MouseX = "Mouse X";
    public string MouseY = "Mouse Y";
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        var horizontal = Input.GetAxis(HorizontalInput);
        var vertical = Input.GetAxis(VerticalInput);


        var movement = new Vector3(horizontal, 0, vertical);

        Animator.SetFloat("Forward", vertical);
        //   Animator.SetFloat("Turning", horizontal);

        // transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        // rotation of player
      //  transform.Rotate(Vector3.up, Input.GetAxisRaw(MouseX) * turnSpeed * Time.deltaTime);
        if (vertical != 0)
        {
            CharacterController.SimpleMove(transform.forward * moveSpeed * vertical);
        }

    }
}
