using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public Transform _player;
    static Animator _myAnim;
    public int _HP;
    public Slider _EnemySlider;
    public int _MaxHP;


	// Use this for initialization
	void Start () {
        _myAnim = GetComponent<Animator>();

        _EnemySlider.maxValue = _MaxHP;
        _HP = _MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(_player.position, this.transform.position) < 15)
        {
            Vector3 lookdistance = _player.position - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(lookdistance), Time.deltaTime * 5.0f);
            
            if (lookdistance.magnitude < 2 && _HP > 1)
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
            }
            else
            {
                _myAnim.SetBool("GobWalk", false);
            }

            if (_HP <= 0)
            {
                _myAnim.SetBool("GobDeath", true);
            }

            _EnemySlider.value = _HP;

        }
	}
}
