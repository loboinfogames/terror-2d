﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;
    private bool verificaChao;
    public Transform chaoVerificador;

    public Transform spritePlayer;
    private Animator animator;
    private bool estaNoChao;



    // Use this for initialization
    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        animator.SetFloat("walking", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));
        animator.SetBool("chao", verificaChao);


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
            

        if (Input.GetKey(KeyCode.W) && verificaChao)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
    }
}
