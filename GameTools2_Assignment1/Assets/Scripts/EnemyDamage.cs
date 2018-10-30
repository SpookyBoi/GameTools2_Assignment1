using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public int _DamageDone;
    public float _Duration;
    private bool _Ready;

	void Start ()
    {
        _Ready = true;
	}

	void Update ()
    {
		
	}

    void OnTriggerStay(Collider _col)
    {
        EnemyController _Enemy = _col.gameObject.GetComponent<EnemyController>();
        
        if (_Enemy == null && !_Ready)
        {
            return;
        }

        else if (_Ready)
        {
            StartCoroutine(Damage(_Enemy));
        }
    }

    IEnumerator Damage(EnemyController _Enemy)
    {
        _Enemy._HP -= _DamageDone;

        _Ready = false;

        yield return new WaitForSeconds(_Duration);

        _Ready = true;
    }
}
