using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    private Animator _myAnim;

	void Start () {
        _myAnim = GetComponent<Animator>();
	}
	
	public void Movement(float rotation, float move)
    {
        _myAnim.SetFloat("Rotation", rotation);
        _myAnim.SetFloat("Move", move);
    }
}
