using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

    private float _Rotation;
    private float _Move;

    private PlayerController _Player;

    private void Start()
    {
        _Player = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        _Rotation = Input.GetAxis("Horizontal");
        _Move = Input.GetAxis("Vertical");

        _Player.Movement(_Rotation, _Move);
    }
}
