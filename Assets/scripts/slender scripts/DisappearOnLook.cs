// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.Rendering.PostProcessing;

// // public class DisappearOnLook : MonoBehaviour
// // {
// //     public float lookTime = 2f;
// //     public float maxDistance = 10f;
// //     private bool isLooking = false;
// //     private Coroutine disappearCoroutine;
// //     public GameObject Glitcheffect;
// //     void Start()
// //     {
        
// //     }

// //     IEnumerator DisappearCoroutine()
// //     {
// //         yield return new WaitForSeconds(lookTime);
// //         Glitcheffect.SetActive(false);
// //         Destroy(gameObject);
// //       // gameObject.SetActive(false);
// //     }

// //     void Update()
// //     {
// //         Vector3 cameraPosition = Camera.main.transform.position;
// //         Vector3 toObject = transform.position - cameraPosition;
// //         float distanceToObject = toObject.magnitude;

// //         if (distanceToObject > maxDistance)
// //         {
// //             if (isLooking)
// //             {
// //                 isLooking = false;
// //                 StopCoroutine(disappearCoroutine);
// //             }
// //             return;
// //         }

// //         Ray ray = new Ray(cameraPosition, toObject.normalized);
// //         RaycastHit hit;

// //         if (Physics.Raycast(ray, out hit))
// //         {
// //             if (hit.collider.gameObject != gameObject)
// //             {
// //                 if (isLooking)
// //                 {
// //                     isLooking = false;
// //                     StopCoroutine(disappearCoroutine);
// //                 }
// //                 return;
// //             }
// //         }


// //         if(Input.GetMouseButtonUp(1))
// //         {
// //             Glitcheffect.SetActive(false);
// //         }
        
// //         if (!isLooking)
// //         {
// //             isLooking = true;
// //         }

// //         if (isLooking && Input.GetMouseButton(1))
// //         {
// //             Glitcheffect.SetActive(true);
            
// //             if (disappearCoroutine == null)
// //             {
// //                 disappearCoroutine = StartCoroutine(DisappearCoroutine());
// //             }
// //         }
// //         else
// //         {
             
            
// //             if (disappearCoroutine != null)
// //             {
// //                 StopCoroutine(disappearCoroutine);
// //                 disappearCoroutine = null;
// //             }
// //         }
// //     }

// //     private void OnDrawGizmosSelected()
// //     {
// //         Gizmos.color = Color.red;
// //         Gizmos.DrawWireSphere(transform.position, maxDistance);
// //     }
// // }

//

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// public class DisappearOnLook : MonoBehaviour
// {
//     [SerializeField] private float lookTime = 2f;
//     [SerializeField] private float maxDistance = 10f;
//     [SerializeField] private GameObject glitchEffect = null;


//     private Coroutine disappearCoroutine = null;
//     private bool isLooking = false;

//     private IEnumerator DisappearCoroutine()
//     {
//         yield return new WaitForSeconds(lookTime);
//         if (glitchEffect != null)
//         {
//             glitchEffect.SetActive(false);
           
//         }
//        gameObject.SetActive(false);
//       // Teleport.instance.TeleportToRandomTarget();
//     }

//     public void Update()
//     {
//         CheckIfLooking();

//         if (!isLooking || !Input.GetMouseButton(1))
//         {
//             StopDisappearing();
              
//             return;
//         }

//         if (disappearCoroutine == null)
//         {
//             StartDisappearing();
//         }
//     }

//     public void CheckIfLooking()
//     {
//         Vector3 cameraPosition = Camera.main.transform.position;
//         Vector3 toObject = transform.position - cameraPosition;
//         float distanceToObject = toObject.magnitude;

//         if (distanceToObject > maxDistance)
//         {
//             StopDisappearing();
//             return;
//         }

//         Ray ray = new Ray(cameraPosition, toObject.normalized);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit))
//         {
//             if (hit.collider.gameObject != gameObject)
//             {
//                 StopDisappearing();
//                 return;
//             }
//         }

//         if (!isLooking)
//         {
//             isLooking = true;
//         }
//     }

//     public void StartDisappearing()
//     {
        
//         if (glitchEffect != null)
//         {
//             glitchEffect.SetActive(true);
//         }
//         disappearCoroutine = StartCoroutine(DisappearCoroutine());
//     }

//     public void StopDisappearing()
//     {
//         if (disappearCoroutine != null)
//         {
//            StopCoroutine(disappearCoroutine);
//            disappearCoroutine = null;
//         }

//         if (glitchEffect != null)
//         {
//             glitchEffect.SetActive(false);
//         }

//        isLooking = false;
//     }
//     public void ResetGlitchEffect()
// {
//     if (glitchEffect != null)
//     {
//         glitchEffect.SetActive(false);
//     }
// }


//     private void OnDrawGizmosSelected()
//     {
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireSphere(transform.position, maxDistance);
//     }
// }



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

    private void Update()
    {
        CheckIfLooking();

        if (!isLooking || !Input.GetMouseButton(1))
        {
            StopDisappearing();
            return;
        }

        if (disappearCoroutine == null)
        {
            StartDisappearing();
        }
    }

    public void CheckIfLooking()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
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
