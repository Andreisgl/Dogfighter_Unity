using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aeronave
{

    /*
        Essa classe calcula o Coeficiente de Empuxo (CL) da asa baseado no Ângulo de Ataque (AoA).
    */

    public class CL_AoA : MonoBehaviour
    {

        private AoA_Calc aoa_Calc;
        void Start()
        {
            aoa_Calc = GetComponent<AoA_Calc>();
            start_empuxoAsa();  //Inicializa os valores da curva
        }

        
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            Debug.Log( getClFromAoA() );
        }


        public AnimationCurve curva;

        void start_empuxoAsa()
            {
                curva.AddKey(-90f, 0f);

                //AoA positivo
                curva.AddKey(0f, 0f);
                curva.AddKey(15f, 1.2f);
                curva.AddKey(25f, 1.6f);
                curva.AddKey(35f, 1.9f);
                
                curva.AddKey(90f, 0f);

                //AoA negativo
                
                curva.AddKey(-15f, -1.2f);
                curva.AddKey(-25f, -1.6f);
                curva.AddKey(-35f, -1.9f);
                
                curva.AddKey(-90f, 0f); 
            }


            //Método de saída:
            public float getClFromAoA()
            {
                return curva.Evaluate( aoa_Calc.getAoAVert() );
            }
    }


}
