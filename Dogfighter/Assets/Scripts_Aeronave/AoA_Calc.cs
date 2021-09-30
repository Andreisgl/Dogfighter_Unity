using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoA_Calc : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    // Start is called before the first frame update
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
