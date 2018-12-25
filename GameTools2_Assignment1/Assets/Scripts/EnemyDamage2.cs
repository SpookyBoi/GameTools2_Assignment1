using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage2 : MonoBehaviour
{
    public int _DamageDone;
    public float _Duration;
    private bool _Ready;

    void Start()
    {
        _Ready = true;
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider _col)
    {
        NewEnemy _REnemy = _col.gameObject.GetComponent<NewEnemy>();

        //_EnemyAnim = _Enemy.GetComponent<Animator>();

        if (_REnemy == null && !_Ready || Input.GetMouseButton(1))//The mouse button part is to prevent the sword from damaging the enemy while blocking since the damage collider can hit the enemy while in the block animation
        {
            return;
        }

        else if (_Ready)
        {
            //_EnemyAnim.SetTrigger("GobImpact");
            StartCoroutine(Damage(_REnemy));
        }

        /*else if (_REnemy == null && !_Ready2 || Input.GetMouseButton(1))
        {
            return;
        }

        else if (_Ready2)
        {
            StartCoroutine(Damage(_REnemy));
            //_REnemy._HP -= 10;
        }*/
    }

    IEnumerator Damage(NewEnemy _REnemy)
    {

        _REnemy._HP -= _DamageDone;

        _Ready = false;

        yield return new WaitForSeconds(_Duration);

        _Ready = true;
    }
}

