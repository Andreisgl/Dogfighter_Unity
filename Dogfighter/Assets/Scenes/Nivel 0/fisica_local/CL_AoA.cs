using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aeronave
{

    /*
        Essa classe calcula o Coeficiente de Empuxo (CL) da asa baseado no Ângulo de Ataque (AoA).

        TODO: Mudar o nome da curva para algo mais apropriado.
    */

    public class CL_AoA : MonoBehaviour
    {

        private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber o AoA e usar para o cálculo nessa classe
        void Start()
        {
            aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instâncuia de AoA_Calc
            start_empuxoAsa();  //Inicializa os valores da curva
        }

        
        void Update() {}

        void FixedUpdate()
        {
            //Debug.Log( getClFromAoA() );
        }


        public AnimationCurve curva;

        void start_empuxoAsa()
            {
                //AoA positivo
                curva.AddKey(0f, 0f);
                curva.AddKey(15f, 1.2f);
                curva.AddKey(25f, 1.6f);
                curva.AddKey(35f, 1.9f);
                
                curva.AddKey(45f, 0f);

                //AoA negativo
                
                curva.AddKey(-15f, -1.2f);
                curva.AddKey(-25f, -1.6f);
                curva.AddKey(-35f, -1.9f);
                
                curva.AddKey(-45f, 0f); 
            }


            //Método de saída:
            public float getClFromAoA()
            {
                return curva.Evaluate( aoa_Calc.getAoAVert() );
            }
    }


}
