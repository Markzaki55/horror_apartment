using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class opencloseDoor : MonoBehaviour ,iintracatable
	{

		public Animator openandclose;
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
			openandclose.Play("Opening");
			open = true;
			SoundManager.PlaySound("opendoor");
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			SoundManager.PlaySound("closedoor");
			yield return new WaitForSeconds(.5f);
		}


	}
