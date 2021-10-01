using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculaCL : MonoBehaviour
{
    /*
    Essa classe calcula o Coeficiente de Empuxo(CL) a partir do ângulo de ataque.
    */
    [SerializeField]
    AnimationCurve curva;   //Inicia a curva de CL.
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    
    void iniciaCurvaCL()    //Inicia os valores da curva de CL. Os valores de CL variam de acordo com o Ângulo de Ataque (AoA)
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
}
