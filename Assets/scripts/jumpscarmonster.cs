using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscarmonster : MonoBehaviour
{
     public float speed = 5f;
    public string nextSceneName = "slender dance";
    public float delayBeforeNextScene = 2f;

    private Transform playerPosition;
    private bool collidedWithPlayer = false;
    private float timeSinceCollision = 0f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;
    }

    private void Update()
    {
        if (!collidedWithPlayer)
        {
            SoundManager.PlaySound("jumpscare1");
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        }
        else
        {
            timeSinceCollision += Time.deltaTime;
            if (timeSinceCollision >= delayBeforeNextScene)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
         transform.LookAt(playerPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collidedWithPlayer = true;
        }
    }
}