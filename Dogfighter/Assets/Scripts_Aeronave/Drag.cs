using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Essa classe aplica arrasto normal e arrasto induzido de acordo com seus cálculos.
*/
public class Drag : MonoBehaviour
{
    //Inicialização de objetos de classes:
    private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber variáveis centrais(AoA, nesse caso) para o cálculo nessa classe.
    private CalculaCL calculaCL;  //Cria instância da classe Calcula para receber variáveis centrais(CL, nesse caso) para o cálculo nessa classe.



    Rigidbody aero_rb;  //Cria um objeto RigidBody.
    
    //Variáveis de física
        private Vector3 velGlobal;   //Vetor que indica a direção e intensidade da Velocidade Local da aeronave.
        float valorArrasto; //Valor da força de arrasto (Drag) a ser aplicada em Newtons.
        float cl;   //Valor do CL.

        [SerializeField]
        float arrInd;   //Valor do Arrasto Induzido (IndDrag)

    void Start()
    {
        aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc
        calculaCL = GetComponent<CalculaCL>();    //Finaliza a criação da instância de AoA_Calc

        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        calculaFisica();
        calculaArrInd();

        aplicaArr();
        //Debug.Log(velGlobal);
    }

    void aplicaArr()    //Essa função aplica o Arrasto
    {
        aero_rb.AddForce(arrInd * -velGlobal);
    }

    void calculaArrInd()    //Calcula o Arrasto Induzido da aeronave.
    {
        arrInd = Mathf.Pow(cl, 2);
    }

    void calculaFisica()
    {
        velGlobal = aero_rb.velocity;  //Atualiza o vetor global velGlobal.
        cl = calculaCL.getCL();
    }
}
