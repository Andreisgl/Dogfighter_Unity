using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{


public class IDrag : MonoBehaviour
{

    //Componentes de outras classes:
        private CL_AoA cl_aoa;  //Cria instância da classe AoA_Calc para receber o AoA e usar para o cálculo nessa classe

    Rigidbody aero_rb;  //Cria um objeto RigidBody

    
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody

        //Componentes de outras classes:
            cl_aoa = GetComponent<CL_AoA>();    //Finaliza a criação da instâncuia de AoA_Calc
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float indDrag = ( Mathf.Sqrt(cl_aoa.getClFromAoA()) );
        aero_rb.AddForce( indDrag * -aero_rb.velocity );
    }
}


}