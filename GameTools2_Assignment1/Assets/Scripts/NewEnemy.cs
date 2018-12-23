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
    NavMeshAgent _myNav;
    [SerializeField] Animator _myAnim;

    private void Start()
    {
        _myNav = GetComponent<NavMeshAgent>();
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {

        transform.LookAt(_Player.transform);

        _dist = Vector3.Distance(transform.position, _Player.transform.position);

        if (_dist < _lookDist)
        {
            _Attack = true;
        }

        if (_Attack)
        {
            _myNav.SetDestination(_Player.transform.position);
            _myAnim.SetBool("isWalk", true);
        }

        else
        {
            _myAnim.SetBool("isWalk", false);
        }
    }
}

