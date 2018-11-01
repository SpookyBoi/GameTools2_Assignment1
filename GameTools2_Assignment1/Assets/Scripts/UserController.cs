using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

    private float _Rotation;
    private float _Move;
    private bool _Sprint;
    private bool _Slash;
    private bool _Block;
    private bool _Impact;
    private bool _Jump;
    private bool _RunSlash;

    private PlayerController _Player;

    private void Start()
    {
        _Player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _Sprint = true;
        }

        else
        {
            _Sprint = false;
        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            _RunSlash = true;
        }

        else
        {
            _RunSlash = false;
        }

        if (Input.GetMouseButtonDown(0) && _RunSlash == false)
        {
            _Slash = true;
        }

        else
        {
            _Slash = false;
        }
    }

    void FixedUpdate()
    {
        _Rotation = Input.GetAxis("Horizontal");
        //_Slash = Input.GetMouseButtonDown(0);
        _Block = Input.GetMouseButton(1);
        _Jump = Input.GetKeyDown(KeyCode.Space);
       // _RunSlash = Input.GetMouseButtonDown(0);


        if (_Sprint == true)
        {
            _Move = Input.GetAxis("Vertical");
        }
        else
        {
            _Move = Mathf.Clamp(Input.GetAxis("Vertical"), -0.5f, 0.5f);
        }

        _Player.Movement(_Rotation, _Move, _Slash, _Block, _Impact, _Jump, _RunSlash);
    }
}
