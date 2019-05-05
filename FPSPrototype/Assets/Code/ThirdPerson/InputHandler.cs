using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    // xbox one controller
    // A = joystick 1 button 0
    // B = 1
    // X = 2
    // Y = 3
    // RightTop 10th Axis
    // RightBottom 5
    // LeftTop 9th Axis
    // LeftBottom 4
    // RightThumbStick 9 = Horizontal Axis (5th), Vertical Axis(4th);
    // LeftThumbstick 8 = Horizontal (X axis), Vertical(Y Axis)
    // PAD = Up/Down (7th Axis), Left/Right (6th Axis)
    // LeftStartButton = 6
    // rightStartButton = 7

    // Trigger Method = if(Input.GetAxis("Trigger") > 0.001)
    // Button Method = joystick 1 button 0
    // JoyPad setting Gravity = 0 , Dead = 1.9 , Sensitivity = 1,  set to joystick axis and joystick nubmer

    // Player
    // Gun
    // Player Look
    // Bomb
    // Pickup
    // FFPsController
    // WeaponSwitching

    // Names of buttons for input Handler XboxController

    // enable or disable players 
    // enable ai or player 2
    // mannage cutscenes and cinimatics
    // mannage game over scenes
    // Input setup names for controler
    //THUMBX1
    //THUMBX2
    //THUMBY1
    //THUMBY2
    //A1
    //A2
    //X1
    //X2
    //B1
    //B2
    //Y1
    //Y2
    //LeftStart1
    //LeftStart2
    //RightStart1
    //RightStart2
    //RT1
    //RT2
    //RB1
    //RB2
    //LT1
    //LT2
    //LB1
    //LB2
    //RSTICKH1
    //RSTICKH2
    //RSTICKV1
    //RSTICKV2
    //PADUP1
    //PADUP2
    //PADLEFT1
    //PADLEFT2


    [Header("Inputs")]
    public string HorizontalInput = "Horizontal";
    public string VerticalInput = "Vertical";
    public string MouseXInput = "Mouse X";
    public string MouseYInput = "Mouse Y";
    public string Fire1 = "Fire1";
    public string Fire2 = "Fire2";

    PlayerController controller;
    PlayerLook look;

    // tutorial variables
    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vertical = Input.GetAxis(VerticalInput);
        Horizontal = Input.GetAxis(HorizontalInput);
        MouseInput = new Vector2(Input.GetAxisRaw(MouseXInput), Input.GetAxisRaw(MouseYInput));
    }

    public void SetUpInputsForGame()
    {

    }
}
