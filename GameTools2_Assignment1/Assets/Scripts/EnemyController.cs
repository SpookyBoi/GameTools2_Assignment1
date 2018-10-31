using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour {

    public Transform _player;
    static Animator _myAnim;
    public int _HP;
    public Slider _EnemySlider;
    public int _MaxHP;
    public Transform _target;
    public UnityEvent _death;
    public UnityEvent _Attack;
    //public UnityEvent _NotAttacking;
    //public UnityEvent _Start;


	void Start () {
        _myAnim = GetComponent<Animator>();

        _EnemySlider.maxValue = _MaxHP;
        _HP = _MaxHP;

	}
	
	void Update () {
		if(Vector3.Distance(_player.position, this.transform.position) < 15)
        {
            Vector3 lookdistance = _player.position - this.transform.position;

            if (_HP > 1)
            {
                transform.LookAt(_target);
            }

            else
            {

            }
            
            if (lookdistance.magnitude < 1 && _HP > 1)
            {
                _myAnim.SetBool("GoblinAttack", true);
                _Attack.Invoke();
            }
            else
            {
                _myAnim.SetBool("GoblinAttack", false);
                //_NotAttacking.Invoke();
            }

            if (lookdistance.magnitude < 8 && _HP > 1)
            {
                _myAnim.SetBool("GobWalk", true);
            }
            else
            {
                _myAnim.SetBool("GobWalk", false);
            }

            if (_HP <= 0)
            {
                _myAnim.SetBool("GobDeath", true);
                _death.Invoke();
            }


            _EnemySlider.value = _HP;

        }
	}
}
