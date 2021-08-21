using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aeronave
{


    public class CL_AoA : MonoBehaviour
    {

        private FisicaLocal fisicaLocal;
        void Start()
        {
            fisicaLocal = GetComponent<FisicaLocal>();
            start_empuxoAsa();  //Inicializa os valores da curva
        }

        
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            Debug.Log( curva.Evaluate( fisicaLocal.getAoAVert() ) );
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
    }


}
