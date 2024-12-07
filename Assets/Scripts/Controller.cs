using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float velocidadMov = 5.0f;
    public float VelocidadRot = 200f;

    private Animator anim;
    public float x, y;
    private Rigidbody rb;

    //variables pel salt
    public float fuerzaSalto = 22f;
    public float fuerzaExtra = 0.4f;

    //public bool Grounded; //toca el terra
    GroundChecker _groundChecker;
    private bool isJumping = false;



    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * VelocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (_groundChecker.Grounded)
        {
            anim.SetBool("Grounded", true);

            if (isJumping)
            {
                isJumping = false;
                anim.SetBool("Salto", false);
            }

            // Si se presiona espacio, inicia el salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping=true;
                anim.SetBool("Salto", true); // Activa la animación de salto
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            //else
            //{
            //    anim.SetBool("Salto", false); // Asegúrate de desactivar "Salto" si está en el suelo
            //}
        }
        else
        {
            anim.SetBool("Grounded", false);
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    anim.SetBool("Salto", true);
        //}
        //if (!Input.GetKeyDown("space"))
        //{
        //    anim.SetBool("Salto", false);
        //}

        // animació salt

    }

    //per desactivar les animacions de salt
    private void Caigo()
    {
        anim.SetBool("Grounded", false);
        anim.SetBool("Salto", false);
    }
}
