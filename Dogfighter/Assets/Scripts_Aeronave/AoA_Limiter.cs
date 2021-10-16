using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Essa classe limita o ÂNGULO DE ATAQUE (AoA) da aeronave.
Ela recebe o ÂNGULO DE ATAQUE (AoA) e aplica um multiplicador <= 1 para limitar a entrada de um ou mais controles para que ela não ultrapasse isso.
*/

public class AoA_Limiter : MonoBehaviour
{

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
        

        multipLimite = calculaLimite();
    }

    float calculaLimite()
    {
        int aoaPos;    //Bandeira int que indica se o ângulo é positivo ou não. 1 = POSITIVO, -1 = NEGATIVO.
            if(aoaVert >= 0) {aoaPos = 1;}
            else {aoaPos = -1;}

        return curvaLimite.Evaluate(aoaVert) * aoaPos;  //Calcula o valor baseado na funçlão da curva e o inverte ou não, baseado em aoaPos. 
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

    //ENCAPSULAMENTO
        //float maxAoa
            public void setMaxAoA(float angulo)
            {
                maxAoa = angulo;
                iniciaCurvaLimite(maxAoa);
            }
            public float getMaxAoa()
            {
                return maxAoa;
            }

        //float aoaVert
            public void setAnguloLimitador(float angulo)    //Obtém o angulo no limitador
            {
                aoaVert = angulo;
            }

    
}
