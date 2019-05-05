using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class TPSPlayer : MonoBehaviour
{
   
    //InputHandler inputHandler;
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }
    [SerializeField]
    float speed;
    [SerializeField]
    MouseInput MouseControl;
    Vector2 mouseInput;

    private MoveController m_MoveController;
    public MoveController MoveController
    {
        get
        {
            if(m_MoveController == null)
            {
                m_MoveController = GetComponent<MoveController>();
            
            }
            return m_MoveController;
        }
    }

    InputHandler playerInput;


    private void Awake()
    {
        playerInput = GameHandler.Instance.InputController;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);

        // handle mouse for cam
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
       transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

      //  transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X"));
    }
}
