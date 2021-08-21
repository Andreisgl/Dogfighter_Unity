using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Aeronave; //Namespace das funções de física, controle e etc.

public class Aeronave_Main : MonoBehaviour
{
    public Rigidbody aero_rb;  //Cria um objeto RigidBody

    //Classes que serão chamadas:
    private FisicaLocal fisicaLocal;
    
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();

        fisicaLocal = GetComponent<FisicaLocal>();

        //
        fisicaLocal.start_fisica();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        fisicaLocal.calculaFisica();

        Debug.Log( fisicaLocal.getAoAVert() );
    }
}
