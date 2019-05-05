using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

   // public event System.Action<TPSPlayer> 
    private GameObject gameObject;

    private static GameHandler m_Instance;
    public static GameHandler Instance
    {
        get {
            {
                if (m_Instance == null)
                {
                    m_Instance = new GameHandler();
                    m_Instance.gameObject = new GameObject("_gameManager");
                    m_Instance.gameObject.AddComponent<InputHandler>();
                }
        }
            return m_Instance;
        }
    }

    private InputHandler m_InputController;
    public InputHandler InputController
    {
        get
        {
            if(m_InputController == null)
            {
                m_InputController = gameObject.GetComponent<InputHandler>();
            }
            return m_InputController;
        }
    }


    private TPSPlayer m_localPlayer;
    public TPSPlayer LocalPlayer
    {
        get
        {
            return m_localPlayer;
        }
        set
        {
           // m
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
