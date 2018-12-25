using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Animator _myAnim;
    public int _HP;
    public int _MaxHP;
    public Slider _PlayerSlider;
    public UnityEvent _Death;
    public Slider _SkillSlider;
    public int _MP;
    public int _MaxMP;
    public UnityEvent _FuryExit;
    public UnityEvent _Fury;
    public UnityEvent _JumpAttackHitbox;
    public UnityEvent _JumpAttackExit;
    public UnityEvent _Deflector;

    public bool Cooldown;
    public bool Walljump;

    public float turn, turnSpeed;


    void Start () {
        _myAnim = GetComponent<Animator>();

        _PlayerSlider.maxValue = _MaxHP;

        _HP = _MaxHP;

        _SkillSlider.maxValue = _MaxMP;
        _MP = _MaxMP;

        Cooldown = true;

        Walljump = false;
	}

    void FixedUpdate()
    {

        turn = (Input.mousePosition.x - (Screen.width / 2)) / Screen.width;

        transform.Rotate(new Vector3(0, turn * turnSpeed, 0), Space.Self);
    }

    public void Movement(float rotation, float move, bool slash, bool block, bool impact, bool jump, bool runSlash)
    {
        _myAnim.SetFloat("Rotation", rotation);
        _myAnim.SetFloat("Move", move);

        if (runSlash)
        {
            _myAnim.SetTrigger("RunSlash");
        }

        if (jump && Walljump == false)
        {
            _myAnim.SetTrigger("Jump");
        }
        if(impact)
        {
            _myAnim.SetTrigger("Impact");
        }
        
        if (slash)
        {
            _myAnim.SetTrigger("Slash");
        }

        if (block)
        {
            _myAnim.SetBool("Block", true);
        }
        else
        {
            _myAnim.SetBool("Block", false);
        }

        if (_HP <= 0)
        {
            _myAnim.SetBool("Death", true);
            StartCoroutine("ReloadOnDeath");
        }

        if (_MP >= 25 && Input.GetKeyDown(KeyCode.Alpha1) && Cooldown == true)
        {
            
            /* _MP -= 25;
             _myAnim.SetTrigger("JumpSlash");*/
            _MP -= 25;
            _myAnim.SetTrigger("JumpSlash");
            StartCoroutine("CooldownJump");
            _JumpAttackHitbox.Invoke();
        }

        if (_MP >= 50 && Input.GetKeyDown(KeyCode.Alpha2) && Cooldown == true)
        {
            _MP -= 50;
            _myAnim.SetTrigger("FurySlash");
            StartCoroutine("CooldownFury");
            StartCoroutine("DamageStart");
        }

        if (Input.GetKey(KeyCode.E) && _MP < _MaxMP)
        {
            _MP += 3;
        }

        if (Input.GetKey(KeyCode.Mouse1) && _HP > 0)
        {
            _Deflector.Invoke();
        }

        else
        {
            
        }

        _PlayerSlider.value = _HP;
        _SkillSlider.value = _MP;

    }

    void OnTriggerStay(Collider _col)
    {
        if (_col.gameObject.CompareTag("Jumpable") && Input.GetKeyDown(KeyCode.Space))
        {
            Walljump = true;
            _myAnim.SetTrigger("Walljump");
            StartCoroutine("Walljumper");
        }
    }
    IEnumerator Walljumper()
    {
        yield return new WaitForSeconds(1f);
        Walljump = false;
    }


    IEnumerator ReloadOnDeath()
    {
        yield return new WaitForSeconds(3f);
        _Death.Invoke();
    }

    IEnumerator DamageStart()
    {
        yield return new WaitForSeconds(0.4f);
        _Fury.Invoke();
    }

    IEnumerator CooldownFury()
    {
        Cooldown = false;
        yield return new WaitForSeconds(3f);
        _FuryExit.Invoke();
        Cooldown = true;
    }

    IEnumerator CooldownJump()
    {
        Cooldown = false;
        yield return new WaitForSeconds(2f);
        _JumpAttackExit.Invoke();
        Cooldown = true;
    }
}
