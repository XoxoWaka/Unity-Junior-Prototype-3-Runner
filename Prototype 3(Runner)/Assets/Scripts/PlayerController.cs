using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle; 
    public ParticleSystem dirtParticle;
    public AudioClip crashSound; 
    public AudioClip jumpSound;
    public float jumpForce = 15f;
    public float gravityModifier;
    public bool isOnGround = true; 
    public bool gameOver;

    
    

    private void Start()
    {
        playerAnim = GetComponent<Animator>(); 
        playerRb = GetComponent<Rigidbody>(); 
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>(); // помещаем компонент AudioSource
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {            
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();


            //воспроизводим jumpSound при прыжке с громкостью 1 то есть с полной громкостью 
            playerAudio.PlayOneShot(jumpSound, 1); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();


            //воспроизводим crashSound при столкновении с препятствием
            playerAudio.PlayOneShot(crashSound, 1); // 
        }
        
    }
}
