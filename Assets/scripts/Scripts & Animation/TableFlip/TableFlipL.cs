using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlipL: MonoBehaviour ,iintracatable
{

	public Animator FlipL;
	public bool open;
	

	void Start (){
		open = false;
	}

	 public void Interact()
    {
        if (!open)
        {
            StartCoroutine(opening());
        }
        else
        {
            StartCoroutine(closing());
        }
    }
	IEnumerator opening(){
		print ("you are opening the door");
        FlipL.Play ("Lup");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
        FlipL.Play ("Ldown");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

