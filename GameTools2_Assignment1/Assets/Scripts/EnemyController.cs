using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform player;
    static Animator myAnim;

	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 lookdistance = player.position - this.transform.position;

            if (lookdistance.magnitude < 2)
            {
                myAnim.SetBool("GoblinAttack", true);
            }
            else
            {
                myAnim.SetBool("GoblinAttack", false);
            }

            if (lookdistance.magnitude < 9)
            {
                myAnim.SetBool("GobWalk", true);
            }
            else
            {
                myAnim.SetBool("GobWalk", false);
            }
        }
	}
}
