using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aeronave_Main : MonoBehaviour
{
    public Rigidbody aero_rb;  //Cria um objeto RigidBody
    
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
