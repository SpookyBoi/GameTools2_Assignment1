using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour {

    public Material[] _material;
    Renderer _myRender;

	void Start ()
    {
        _myRender = GetComponent<Renderer>();
        _myRender.enabled = true;
        _myRender.sharedMaterial = _material[0];
	}
	
	void Update ()
    {
        StartCoroutine("Test");
	}


    IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);
        _myRender.sharedMaterial = _material[1];
    }
}
