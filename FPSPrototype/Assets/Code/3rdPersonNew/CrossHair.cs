using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrossHair : MonoBehaviour
{

    public Image CrossUp;
    public Image CrossDown;
    public Image CrossLeft;
    public Image CrossRight;
    public float SpredAmount = 10;
    public float speed;
    public bool aiming;
    public float DistanceMultiplyer = 7f;
   
    PlayerLook look;


     




    // Start is called before the first frame update
    void Start()
    {
     look =   gameObject.GetComponentInChildren<PlayerLook>();
 
      
    }

    // Update is called once per frame
    void Update()
    {
        if(look.mouseX != 0 || look.mouseY != 0 && aiming == false )
        {

            aiming = true;
            CrossHairsMoveing();
            Debug.Log("Aiming");
         
        }
      else  if (look.mouseX == 0 || look.mouseY == 0 && aiming == true )
        {
            aiming = false;

            CrossHairsStill();
            Debug.Log(" Not Aiming");
        }
    }

    public void CrossHairsMoveing()
    {
        // move cross hairs when player moves
        // up
     Vector3   moveUp = new Vector3(0,  SpredAmount * DistanceMultiplyer, 0);
        // down
   Vector3 moveDown  = new Vector3(0,  - SpredAmount * DistanceMultiplyer, 0);
        // left
       Vector3 moveLeft = new Vector3(- SpredAmount * DistanceMultiplyer, 0 , 0);
        // right
       Vector3 moveRight = new Vector3( SpredAmount * DistanceMultiplyer, 0 , 0);



        CrossUp.rectTransform.localPosition = Vector3.Lerp(CrossUp.rectTransform.localPosition, moveUp, speed * Time.deltaTime);
        CrossDown.rectTransform.localPosition = Vector3.Lerp(CrossDown.rectTransform.localPosition, moveDown, speed * Time.deltaTime);
        CrossLeft.rectTransform.localPosition = Vector3.Lerp(CrossLeft.rectTransform.localPosition, moveLeft, speed * Time.deltaTime);
        CrossRight.rectTransform.localPosition = Vector3.Lerp(CrossRight.rectTransform.localPosition, moveRight, speed * Time.deltaTime);
    }

    public void CrossHairsStill()
    {
        // move cross hairs when player moves
        // up
        Vector3 moveUp = new Vector3(0, SpredAmount , 0);
        // down
        Vector3 moveDown = new Vector3(0, -SpredAmount , 0);
        // left
        Vector3 moveLeft = new Vector3(-SpredAmount , 0, 0);
        // right
        Vector3 moveRight = new Vector3(SpredAmount , 0 , 0);

        CrossUp.rectTransform.localPosition = Vector3.Lerp(CrossUp.rectTransform.localPosition, moveUp, speed * Time.deltaTime);
        CrossDown.rectTransform.localPosition = Vector3.Lerp(CrossDown.rectTransform.localPosition, moveDown, speed * Time.deltaTime);
        CrossLeft.rectTransform.localPosition = Vector3.Lerp(CrossLeft.rectTransform.localPosition, moveLeft, speed * Time.deltaTime);
        CrossRight.rectTransform.localPosition = Vector3.Lerp(CrossRight.rectTransform.localPosition, moveRight, speed * Time.deltaTime);
    }
}
