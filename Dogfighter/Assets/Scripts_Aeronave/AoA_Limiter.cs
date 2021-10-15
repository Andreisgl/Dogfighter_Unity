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

    //Variáveis de física
        [SerializeField]
        float aoaVert;  //AoA vertical atual da aeronave.

        [SerializeField]
        float maxAoa;   //AoA máximo da aeronave.

        [SerializeField]
        float multipLimite; //Valor da limitação do AoA. Valor entre 0 e 1
        
        [SerializeField]
        AnimationCurve curvaLimite;

    void Start()
    {
        aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc

        //DECLARAÇÃO PROVISÓRIA DO AOA MÁXIMO!!!
        maxAoa = 20f;
        iniciaCurvaLimite(maxAoa);  //Inicia a curva de limitação, com o valor máximo de AoA como parâmetro.
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        atualizaVariaveis();
        
    }

    void atualizaVariaveis()
    {
        // VER DEPOIS !!!!!! Talvez eu permita a utilização flexível de outro tipo de ângulo depois, sem limitar ao AoA Vertical. 
        aoaVert = aoa_Calc.getAoAVert();

        multipLimite = curvaLimite.Evaluate(aoaVert);
    }


    void iniciaCurvaLimite(float max)   //Atualiza a curva com os valores máximos de AoA.
    {
        //curvaLimite.AddKey(-180, 0);
        ///curvaLimite.AddKey(-(max-1), 0);
        curvaLimite.AddKey(-max, 0);

        curvaLimite.AddKey(0f, 1f);

        curvaLimite.AddKey(max, 0);
        //curvaLimite.AddKey(180, 0);
    }

    
}
