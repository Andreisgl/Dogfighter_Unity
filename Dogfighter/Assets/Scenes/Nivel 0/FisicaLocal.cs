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

        }


        void CalculateState(float dt, bool firstThisFrame)
        {
            var invRotation = Quaternion.Inverse(Rigidbody.rotation);
            Velocity = Rigidbody.velocity;
            LocalVelocity = invRotation * Velocity;  //transform world velocity into local space
            LocalAngularVelocity = invRotation * Rigidbody.angularVelocity;  //transform into local space

            CalculateAngleOfAttack();

        }

        void CalculateAngleOfAttack()
        {
            AngleOfAttack = Mathf.Atan2(-LocalVelocity.y, LocalVelocity.z);
            AngleOfAttackYaw = Mathf.Atan2(LocalVelocity.x, LocalVelocity.z);
        }
        //Métodos de saída:
     



        //Métodos de encapsulamento

        public Vector3 getVelLocal()
        {
            return velLocal;
        }
    }



}
