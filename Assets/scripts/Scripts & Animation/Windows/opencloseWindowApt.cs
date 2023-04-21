using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class opencloseWindowApt : MonoBehaviour,iintracatable
	{

		public Animator openandclosewindow;
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
			print("you are opening the Window");
			openandclosewindow.Play("Openingwindow");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandclosewindow.Play("Closingwindow");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
