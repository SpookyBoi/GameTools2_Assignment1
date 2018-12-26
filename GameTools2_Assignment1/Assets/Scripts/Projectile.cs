using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float _speed;

	void Update ()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider _col)
    {
        

        if (_col.gameObject.tag == "Player" || _col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (_col.gameObject.tag == "RangedEnemy")
        {
            GameObject.Find("RangedEnemy").GetComponent<NewEnemy>()._HP -= 10;
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

}
