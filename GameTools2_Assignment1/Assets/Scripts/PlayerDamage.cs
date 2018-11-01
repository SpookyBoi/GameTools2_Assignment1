using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public int _DamageDone;
    public int _Duration;
    private bool _Ready;

	void Start ()
    {
        _Ready = true;
	}
	
	void Update ()
    {
		
	}

    /*void OnTriggerStay(Collider _col)
    {
        PlayerController _Player = _col.gameObject.GetComponent<PlayerController>();

        if (_Player == null && !_Ready)
        {
            return;
        }

        else if (_Ready)
        {
            StartCoroutine(Damage(_Player));
        }
    }*/

    public void GobHit()
    {
        PlayerController _Player = gameObject.GetComponent<PlayerController>();
        StartCoroutine(Damage(_Player));

    }

    IEnumerator Damage(PlayerController _Player)
    {
        _Player._HP -= _DamageDone;

        _Ready = false;

        yield return new WaitForSeconds(_Duration);

        _Ready = true;
    }
}
