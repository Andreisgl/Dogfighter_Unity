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
        [SerializeField]
        private Vector3 velGlobal;   //Vetor que indica a direção e intensidade da Velocidade Local da aeronave.

        //[SerializeField]
        float valorArrasto; //Valor da força de arrasto (Drag) a ser aplicada em Newtons.

        [SerializeField]
        float cl;   //Valor do CL.
        //Coeficientes:
            [SerializeField]
            float cdi;  //Coeficiente de arrasto induzido.
            float cd;   //Coeficiente de arrasto.
        
        //Cálculo do Arrasto:
            float densAr = 1;   //Densidade do ar em kg/m^3. VALOR PROVISÓRIO!!

            [SerializeField]
            float veloc2;    //Velocidade ao quadrado.
            float area = 28;     //Área da asa em m^2. VALOR PROVISÓRIO!!

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
        

        aplicaArr();
        //Debug.Log(velGlobal);

        

        
    }

    float calculaCDI()  //Calcula o coeficiente de Arrasto Induzido(CDI).
    {
        return Mathf.Pow(cl, 2) / (3.14f * 3.5f);
    }

    float calculaArrasto(float coef)  //Fórmula simples de arrasto. Recebe um coeficiente, retorna a força.
    {
        return coef * densAr * (veloc2 /2) * area;
    }


    void aplicaArr()    //Essa função aplica a força de Arrasto.
    {
        aero_rb.AddForce(arrInd * -velGlobal);
    }

    void calculaFisica()
    {
        velGlobal = aero_rb.velocity;  //Atualiza o vetor global velGlobal.
        cl = calculaCL.getCL(); //Atualiza CL.
        cdi = calculaCDI(); //Atualiza CDI.
            //cdi = 0.0175f;
        veloc2 = velGlobal.sqrMagnitude;    //Atualiza a velocidade ao quadrado da aeronave.
        arrInd = calculaArrasto(cdi);   //Atualiza o valor do Arrasto Induzido (ArrInd)
    }
}
