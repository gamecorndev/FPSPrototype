using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    public Transform muzzle;

    float nextFireAllowed;
    bool canFire;

    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
    }

    public void Fire()
    {
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;
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
