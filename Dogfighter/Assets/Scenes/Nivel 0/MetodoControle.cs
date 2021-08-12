using System.Collections;
using System.Collections.Generic;
using UnityEngine;

Namespace Aeronave
{



public class MetodoControle : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody

    // Start is called before the first frame update
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



}