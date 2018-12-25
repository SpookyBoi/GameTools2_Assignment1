using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.AI;

public class NewEnemy : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] float _dist, _lookDist;
    [SerializeField] bool _Attack;
    [SerializeField] bool _Chase;
    NavMeshAgent _myNav;
    [SerializeField] Animator _myAnim;

    //Projectile stuff
    public Projectile _projectile;
    public float _projectileSpeed;
    public float _timeBetweenShots;
    private float _shotCounter;

    //HP
    public int _HP;
    public Slider _RangedEnemyHealth;
    public int _MaxHP;

    public Transform _firePoint;

    private void Start()
    {
        _myNav = GetComponent<NavMeshAgent>();
        _Player = GameObject.FindGameObjectWithTag("Player");

        _RangedEnemyHealth.maxValue = _MaxHP;
        _HP = _MaxHP;
    }

    private void Update()
    {
        _RangedEnemyHealth.value = _HP;
        transform.LookAt(_Player.transform);

        _dist = Vector3.Distance(transform.position, _Player.transform.position);

        if (_dist < _lookDist)
        {
            _Chase = true;
        }

        if (_Chase)
        {
            _myNav.SetDestination(_Player.transform.position);
            _myAnim.SetBool("isWalk", true);
        }

        else
        {
            _myAnim.SetBool("isWalk", false);
        }

        if (_dist < 8)
        {
            _Attack = true;
        }

        else if (_dist > 8)
        {
            _Attack = false;
        }

        if (_Attack == true)
        {
            _myAnim.SetTrigger("isAttack");
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0)
            {
                StartCoroutine("Attacking");
                _shotCounter = _timeBetweenShots;
            }
        }
        else
        {
            _shotCounter = 0;
        }
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(1.22f);
        Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
    }
}


