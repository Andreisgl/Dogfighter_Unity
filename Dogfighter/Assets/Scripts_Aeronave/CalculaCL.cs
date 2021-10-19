using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Essa classe calcula o Coeficiente de Empuxo(CL) a partir do ângulo de ataque.
*/  


public class CalculaCL : MonoBehaviour
{
    //Inicialização de objetos de classes:
    private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber variáveis centrais(AoA, nesse caso) para o cálculo nessa classe.
    
    //Variáveis de física:
        [SerializeField]
        float clAtual;  //Coeficiente de Empuxo(CL) atual.
        float aoaVert;  //Ângulo de Ataque (AoA) vertical.
        [SerializeField]
        AnimationCurve curva;   //Inicia a curva de CL.
    
    void Start()
    {
        aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc
        iniciaCurvaCL();
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
        //AoA:
            aoaVert = aoa_Calc.getAoAVert();
        //CL:
            clAtual = getCL();
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

    //Encapsulamento:
    public float getCL()
    {
        return curva.Evaluate( aoaVert );
    }
}
