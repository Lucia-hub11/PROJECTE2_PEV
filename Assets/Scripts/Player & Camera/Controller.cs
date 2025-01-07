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

    public bool hasPistol=false;

    //Items
    public GameObject nearItem;
    public GameObject itemPrefab;
    public Transform itemSlot;
    public GameObject crosshair;  //Mirilla

    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        hasPistol = true;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        ItemLogic();

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * VelocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // animació salt
        if (_groundChecker.Grounded)
        {
            anim.SetBool("Grounded", true);

            if (isJumping)
            {
                isJumping = false;
                anim.SetBool("Salto", false);
            }

            // Si es fa clic a l'espai, inicia el salt
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping=true;
                anim.SetBool("Salto", true); // Activa l'animació de saltar
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }

        }
        else
        {
            anim.SetBool("Grounded", false);
        }

        anim.SetBool("holdPistol", hasPistol);
        if (hasPistol)
        {
            anim.SetLayerWeight(1, 1);
        }
    }

    public void ItemLogic()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("Item"))
        {
            Debug.Log("Hi ha un objecte aprop!");
            nearItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("Ja no hi ha items aprop...");
            nearItem = null;
        }
    }
}
