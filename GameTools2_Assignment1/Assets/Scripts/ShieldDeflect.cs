using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeflect : MonoBehaviour {

    public Projectile projectile1;
    public float _projectileSpeed;
    public Transform _firePoint;

    void OnTriggerEnter(Collider _col)
    {
        Projectile _Projectile = _col.gameObject.GetComponent<Projectile>();

        if (_Projectile == null)
        {
            //Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
            return;
        }

        else
        {
            Instantiate(projectile1, _firePoint.position, _firePoint.rotation);
        }
    }
}
