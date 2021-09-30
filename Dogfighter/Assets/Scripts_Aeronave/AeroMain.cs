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
public class AeroMain : MonoBehaviour
{
    private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber o AoA e usar para o cálculo nessa classe
    
    //Variáveis CENTRAIS:
        //AoA_Calc
        float aoaVert;
        float aoaHor;
    


    void Start()
    {
        aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        atualizaVariaveisCentrais();
        Debug.Log( "MAIN:  AoA V: " + aoaVert + "   AoA H: " + aoaHor );
    }

    void atualizaVariaveisCentrais()    //Essa função atualiza os valores das variáveis de cada
    {
        //AoA_Calc:
            aoaVert = aoa_Calc.getAoAVert();
            aoaHor = aoa_Calc.getAoAHor();

    }

}
