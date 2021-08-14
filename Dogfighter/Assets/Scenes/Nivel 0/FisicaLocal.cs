using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{

    /*
    Essa classe é responsável por administrar forças e atributos físicos da aeronave como:
        -Massa,             **PENDENTE**
        -Velocidade local,  **PENDENTE**
        -Ângulo de ataque,  **EM ANDAMENTO**
        -Empuxo das asas    **PENDENTE**

    */

    public class FisicaLocal : MonoBehaviour
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

        void FixedUpdate()
        {
            teste();
        }

        void teste()
        {
            //Quaternion qForward = Quaternion.LookRotation(transform.forward);   //Cria um quatérnio que aponta a posição local para frente.
            //Quaternion qVelLocal = Quaternion.LookRotation(transform.InverseTransformDirection(aero_rb.velocity));  //Quatérnio que aponta para a velocidade local.

            
            
            //var invRotation = Quaternion.Inverse(aero_rb.rotation);
            //Vector3 Velocity = aero_rb.velocity;
            //var LocalVelocity = invRotation * Velocity;  //transform world velocity into local space

            //Aoa:

            //var AngleOfAttack = Mathf.Atan2(-LocalVelocity.y, LocalVelocity.z);
            //var AngleOfAttackYaw = Mathf.Atan2(LocalVelocity.x, LocalVelocity.z);

            //Debug.Log( LocalVelocity + " vs " + ( transform.InverseTransformDirection(aero_rb.velocity) ) );

            Vector3 velLocal = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );

            Vector3 dir = velLocal - transform.forward;

            Debug.Log( dir );

        }


        //Métodos de saída:
     



        //Métodos de encapsulamento

    }



}
