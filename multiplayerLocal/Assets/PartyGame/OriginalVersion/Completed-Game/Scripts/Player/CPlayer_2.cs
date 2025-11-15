using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer_2 : PlayerController
{
    public Rigidbody _rigidbodyA;
    private Animator animatorController;

    [Header("Animation Attributes")]
    public float AnimationSpeed = 0;
    public bool ISjumpAnimation = false;
    public bool IsPunchAnimation = false;

    [Header("Attack Lists")]
    [SerializeField] public List<CAttack> _attackList;
    [SerializeField] public List<CAttack> _attackTempList= new List<CAttack>();

    [SerializeField] private List<CComboAttack> _comboList;
    [SerializeField] private List<CComboAttack> _comboTempList = new List<CComboAttack>();
    
    public CPlayer_2()
    {

    }
    public override void Start()
    {
        base.Start();
        _rigidbodyA = GetComponent<Rigidbody>();
        animatorController = GetComponent<Animator>();
        animatorController.Play("Idle");
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        ControllerAnimation();
    }

    

    public override void EspecialHability()
    {
        base.EspecialHability();

    }
    public override void AsignControll()
    {
        base.AsignControll();

    }
    public override void P2Controller()
    {
        base.P2Controller();
        _rigidbodyA.linearVelocity = (movement * speed);
    }
    public void ControllerAnimation()
    {

        animatorController.SetFloat("Speed", movement.magnitude);


        if (AnimationSpeed > 0)
        {
            AnimationSpeed -= 0.10f;
            animatorController.SetFloat("Speed", movement.magnitude);
        }

        else if (AnimationSpeed <= 0)
        {
            AnimationSpeed = 0;
            animatorController.SetFloat("Speed", movement.magnitude);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            ISjumpAnimation = true;
            animatorController.SetBool("IsJump", ISjumpAnimation);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ISjumpAnimation = false;
            animatorController.SetBool("IsJump", ISjumpAnimation);

        }

    }




}



