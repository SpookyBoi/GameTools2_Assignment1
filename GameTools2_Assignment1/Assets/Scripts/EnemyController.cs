﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class EnemyController : MonoBehaviour
{

    public Transform _player;
    [SerializeField] Animator _myAnim;
    public int _HP;
    public Slider _EnemySlider;
    public int _MaxHP;
    public Transform _target;
    public UnityEvent _death;
    public int _DamageDone;
    private Animator _PlayerAnim;
    public UnityEvent _destroyModel;

    void Start()
    {
        _myAnim = GetComponent<Animator>();

        _EnemySlider.maxValue = _MaxHP;
        _HP = _MaxHP;
    }

    void Update()
    {
        _EnemySlider.value = _HP;

        if (Vector3.Distance(_player.position, this.transform.position) < 8)
        {
            Vector3 lookdistance = _player.position - this.transform.position;


            if (lookdistance.magnitude < 1 && _HP > 1)
            {
                _myAnim.SetBool("GoblinAttack", true);
            }
            else
            {
                _myAnim.SetBool("GoblinAttack", false);
            }

            if (lookdistance.magnitude < 8 && _HP > 1)
            {
                _myAnim.SetBool("GobWalk", true);
                transform.LookAt(_target);
            }
            else
            {
                _myAnim.SetBool("GobWalk", false);
            }

            if (_HP <= 0)
            {
                _myAnim.SetBool("GobDeath", true);
                _death.Invoke();
                StartCoroutine("ModelDestroyer");
            }
        }
    }

    IEnumerator ModelDestroyer()
    {
        yield return new WaitForSeconds(2f);
        _destroyModel.Invoke();
    }
   
    public void GobHit()
    {

        if (Input.GetMouseButton(1))
        {
            GameObject.Find("Player").GetComponent<PlayerController>()._HP -= 0;
        }

        else
        {
            GameObject.Find("Player").GetComponent<PlayerController>()._HP -= _DamageDone;
        }

    }
}