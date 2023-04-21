using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class OvenFlip: MonoBehaviour, iintracatable
	{

		public Animator openandcloseoven;
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
			openandcloseoven.Play("OpenOven");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandcloseoven.Play("ClosingOven");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
