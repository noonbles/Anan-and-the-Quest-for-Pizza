using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePowerUp : MonoBehaviour
{
    public Text addTime;
    private Vector3 originalPosition;
    private bool visited;
    public AudioClip source;
    void Start()
    {
        originalPosition = transform.position;
        visited = false;
    }

    void Update(){
        transform.Rotate(Vector3.up * 30f * Time.deltaTime, Space.World);
        float yOffset = Mathf.Sin(Time.time * 3f) * 0.2f;
        transform.position = new Vector3(transform.position.x, originalPosition.y + yOffset, transform.position.z);
    }
    void OnTriggerEnter(Collider collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p && !visited)
        {
            visited = true;
            AudioSource audioSource = p.GetComponent<AudioSource>();
            audioSource.clip = source;
            audioSource.Play();
            gameObject.SetActive(false);
            p.currentTime += 5f;
            LeanTween.moveY(addTime.gameObject, 680, 1.0f).setOnComplete(()=>{
                Invoke("delayLeaveAnim", 1.0f);
            });
        }
    }

    void delayLeaveAnim() { LeanTween.moveY(addTime.gameObject, 1200, 1.0f); Destroy(gameObject); }
}