using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] float _FOV;
    [SerializeField] float _ThresholdDist;
    [SerializeField] private Transform[] _Waypoints;
    [SerializeField] GameObject _Player;

    private NavMeshAgent _myNav;
    private int _CurrentWP;
    private enum eState { FOLLOW, PATROL };
    private eState _eState;

    bool _Nearby;

    private Animator _myAnim;

    void Start()
    {
        _eState = eState.PATROL;
        _myNav = GetComponent<NavMeshAgent>();
        _CurrentWP = 0;
        _myAnim = GetComponent<Animator>();

        _myNav.updatePosition = false;
        _myNav.updateRotation = true;

        DoAnims();
    }

    // Update is called once per frame
    void Update()
    {

        CheckForPlayer();
        _myNav.nextPosition = transform.position;

        switch (_eState)
        {
            case eState.FOLLOW:
                Follow();
                break;

            case eState.PATROL:
                Patrol();
                break;

            default:
                break;
        }
    }

    void CheckForPlayer()
    {
        if (_eState == eState.PATROL && _Nearby && CheckFOV() && CheckOclusion())
        {
            _eState = eState.FOLLOW;
            DoAnims();
            return;
        }

        if (_eState == eState.FOLLOW && !CheckOclusion())
        {
            _eState = eState.PATROL;
            DoAnims();
        }
    }

    void Follow()
    {
        _myNav.SetDestination(_Player.transform.position);
    }

    bool CheckFOV()
    {
        Vector3 distance = _Player.transform.position - this.transform.position;
        Vector3 angle = (Quaternion.FromToRotation(transform.forward, distance)).eulerAngles;


        if (angle.y > 180.0f) angle.y = 360.0f - angle.y;
        else if (angle.y < -180.0f) angle.y = angle.y + 360.0f;


        if (angle.y < _FOV / 2)
        {
            return true;
        }

        return false;
    }

    bool CheckOclusion()
    {
        RaycastHit hit;

        Vector3 direction = _Player.transform.position - transform.position;

        if (Physics.Raycast(this.transform.position, direction, out hit))
        {
            if (hit.collider.gameObject == _Player)
            {
                return true;
            }
        }
        return false;
    }

    void Patrol()
    {
        CheckWaypointDist();
        _myNav.SetDestination(_Waypoints[_CurrentWP].position);
    }

    void CheckWaypointDist()
    {
        if (Vector3.Distance(_Waypoints[_CurrentWP].position, this.transform.position) < _ThresholdDist)
        {
            _CurrentWP = (_CurrentWP + 1) % _Waypoints.Length;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") //&& CheckFieldOfView() )
        {
            _Nearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _Nearby = false;
        }
    }

    private void OnColliderStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }

    void DoAnims()
    {
        if (_eState == eState.FOLLOW)
        {
            _myAnim.SetBool("isWalk", true);
        }
        else
        {
            _myAnim.SetBool("isWalk", true);
        }
    }
}