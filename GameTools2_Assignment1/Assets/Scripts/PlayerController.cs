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


	void Start () {
        _myAnim = GetComponent<Animator>();

        _PlayerSlider.maxValue = _MaxHP;

        _HP = _MaxHP;
	}
	
	public void Movement(float rotation, float move, bool slash, bool block, bool impact, bool jump, bool runSlash)
    {
        _myAnim.SetFloat("Rotation", rotation);
        _myAnim.SetFloat("Move", move);

        if (runSlash)
        {
            _myAnim.SetTrigger("RunSlash");
        }

        if (jump)
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
            _Death.Invoke();
        }

        _PlayerSlider.value = _HP;
    }
}
