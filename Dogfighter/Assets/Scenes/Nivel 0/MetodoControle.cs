using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
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

        void FixedUpdate()
        {

        }

        private float fator = 0;    //Multiplica a entrada para aumentar ou diminuir a intensidade da saída. Pode ser alterado por "saidaControle()"

        //Métodos de encapsulamento
        public void setFator(float novoFator) //Permite definir externamente o fator de entrada.
        {
            fator = novoFator;
        }


        //Metodos de ação
        public float saidaControle(float entrada)   //Recebe a entrada, o multiplica pelo fator e retorna o resultado.
        {
            return fator * entrada;
        }

        
    }



}