


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisappearOnLook : MonoBehaviour
{
    [SerializeField] private float lookTime = 2f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private GameObject glitchEffect = null;
    [SerializeField] private float collisionChance = 0.35f;
    [SerializeField] private float collisionSpeed = 2f;
    [SerializeField] private Transform playerTransform = null; 
    private Coroutine disappearCoroutine = null;
    private bool isLooking = false;
    private bool hasBeenRemoved = false;
    private Camera maincam;
    private bool hasExcuted = true;


    private void Start()
    {
        maincam = Camera.main;
    }
    private void Update()

    {
        CheckIfLooking();

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

    float rand = Random.Range(0f, 1f);
    bool shouldCollide = rand <= collisionChance; 



     if (shouldCollide)
    {
       
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        SoundManager.PlaySound("jumpscare1");
        while (Vector3.Distance(transform.position, playerTransform.position) > 0.1f)
        {
            transform.position += direction * collisionSpeed * Time.deltaTime;
            transform.LookAt(playerTransform.position); // Look at the player
            yield return null;
        }

      
   
    }

        if(!shouldCollide){

        yield return new WaitForSeconds(lookTime);

        if (true)
        {
            if (glitchEffect != null)
            {
                glitchEffect.SetActive(false);
            }

           
            Teleport.instance.TeleportToRandomTarget();

            hasBeenRemoved = true;
        }
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

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.transform.CompareTag("Player"))
        {
             float LoseChance = 0.35f;
    float randDance = Random.Range(0f, 1f);
    if (randDance <= LoseChance)
    {
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
        SceneManager.LoadScene("slender dance");
       
    }
 Teleport.instance.TeleportToRandomTarget();

        }
        
    }
}



