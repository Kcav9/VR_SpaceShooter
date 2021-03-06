using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject explosionParticles;
    [SerializeField] private Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="projectile")
        {
            print("hit");
            print(transform.position);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
            Destroy(gameObject);
            score.text = (int.Parse(score.text) + 1).ToString();
        }
    }
}
