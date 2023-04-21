using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class Drawer_Pull_Zopp : MonoBehaviour, iintracatable
	{

		public Animator pull;
		public bool open;
		
		void Start()
		{
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
		IEnumerator opening()
		{
			print("you are opening the door");
			pull.Play("openpullopp");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			pull.Play("closepushopp");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
