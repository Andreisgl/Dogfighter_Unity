using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Essa classe limita o ÂNGULO DE ATAQUE (AoA) da aeronave.
Ela recebe o ÂNGULO DE ATAQUE (AoA) e aplica um multiplicador <= 1 para limitar a entrada de um ou mais controles para que ela não ultrapasse isso.
*/

public class AoA_Limiter : MonoBehaviour
{
    //Inicialização de objetos de classes:
    private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber variáveis centrais(AoA, nesse caso) para o cálculo nessa classe.


    void Start()
    {
        aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc
    }

    void Update()
    {
        
    }
}
