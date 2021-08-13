using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{


    /*
    Essa classe é responsável por criar os métodos para a operação dos controles da aeronave.
    Eles serão associados a entradas na classe "Controles"
    */

    public class MetodoControle //
    {
        

        // Start is called before the first frame update
        void Start()
        {
            
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
        public void getFator()
        {
            return fator;
        }


        //Metodos de ação
        public float saidaControle(float entrada)   //Recebe a entrada, o multiplica pelo fator e retorna o resultado.
        {
            return fator * entrada;
        }

        
    }



}