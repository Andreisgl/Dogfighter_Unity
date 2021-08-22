using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aeronave
{

    /*
        Essa classe aplica a força de Empuxo (Lift) das asas baseado em:
        -Ângulo de Ataque(AoA): Calculado na classe AoA_Calc.
        -Coeficiente de Empuxo(CL): Calculado na classe CL_AoA.
    */

    public class Lift_Force : MonoBehaviour
    {

        void Start()
        {
            //**Isso é provisório! Devo adicionar depois um script que aplica esses fatores baseado em dados pré-definidos de modelos de aeronaves!
        }

    
        void Update()
        {
            
        }
    }


}