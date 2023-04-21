using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class opencloseSlide : MonoBehaviour,iintracatable
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
			openandclosewindow.Play("OpeningSlide");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandclosewindow.Play("ClosingSlide");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
