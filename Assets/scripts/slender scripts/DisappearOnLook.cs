


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnLook : MonoBehaviour
{
    [SerializeField] private float lookTime = 2f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private GameObject glitchEffect = null;

    private Coroutine disappearCoroutine = null;
    private bool isLooking = false;
    private bool hasBeenRemoved = false;
    private Camera maincam;

    private bool hasExcuted = false;


    private void Start()
    {
        maincam = Camera.main;
    }
    private void Update()

    {
        CheckIfLooking();


        if (!hasExcuted)
        {
            if (!isLooking || !Input.GetMouseButton(1))
            {
                StopDisappearing();
                return;
            }
            hasExcuted = true;

        }
        if(hasExcuted){
            if(!isLooking)
            {
                 StopDisappearing();
                return;

            }
        }



        if (disappearCoroutine == null)
        {
            StartDisappearing();
        }
    }

    public void CheckIfLooking()
    {
        Vector3 cameraPosition = maincam.transform.position;
        Vector3 toObject = transform.position - cameraPosition;
        float distanceToObject = toObject.magnitude;

        if (distanceToObject > maxDistance)
        {
            StopDisappearing();
            return;
        }

        Ray ray = new Ray(cameraPosition, Camera.main.transform.forward);
        Debug.DrawRay(cameraPosition, Camera.main.transform.forward * maxDistance);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject != gameObject)
            {
                StopDisappearing();
                return;
            }
            if (!isLooking)
            {
                isLooking = true;
            }
        }


    }

    private IEnumerator DisappearCoroutine()
    {
        yield return new WaitForSeconds(lookTime);

        if (true)
        {
            if (glitchEffect != null)
            {
                glitchEffect.SetActive(false);
            }

            //gameObject.SetActive(false);
            Teleport.instance.TeleportToRandomTarget();

            hasBeenRemoved = true;
        }
    }

    private void StartDisappearing()
    {
        if (glitchEffect != null)
        {
            glitchEffect.SetActive(true);
        }

        disappearCoroutine = StartCoroutine(DisappearCoroutine());
    }

    private void StopDisappearing()
    {
        if (disappearCoroutine != null)
        {
            StopCoroutine(disappearCoroutine);
            disappearCoroutine = null;
        }

        if (glitchEffect != null)
        {
            glitchEffect.SetActive(false);
        }

        isLooking = false;
    }

    private void ResetGlitchEffect()
    {
        if (glitchEffect != null)
        {
            glitchEffect.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
