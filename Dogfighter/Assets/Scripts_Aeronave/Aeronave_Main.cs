using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Essa classe reúne dados e estados provenientes de outras classes para acesso mais limpo. 
*/

/*
TODO:
    -Transferir dados de outras classes para cá.
    -Ver o que fazer com IndDrag.
*/
public class Aeronave_Main : MonoBehaviour
{
    private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber o AoA e usar para o cálculo nessa classe
    

    void Start()
    {
        aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Debug.Log( "MAIN:  AoA V: " + aoa_Calc.getAoAVert() + "   AoA H: " + aoa_Calc.getAoAHor() );
    }

}
