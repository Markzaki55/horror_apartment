using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SlenderJumpScare : MonoBehaviour
{
    public float speed = 10f;
    public float jumpScareDistance = 10f;
    public AudioClip jumpScareSoundEffect;
    public string nextSceneName;

    private Transform player;
    private bool triggeredJumpScare = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!triggeredJumpScare)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (distance <= jumpScareDistance)
            {
                triggeredJumpScare = true;
                StartCoroutine(SlenderManJumpScare());
            }
        }
    }

    IEnumerator SlenderManJumpScare()
    {
        //SoundManager.PlaySound();

        yield return new WaitForSeconds(jumpScareSoundEffect.length);

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(nextSceneName);
    }
}