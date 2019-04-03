using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_controller : MonoBehaviour
{
    [SerializeField] AudioClip[] punches;

    [SerializeField] AudioClip jab;
    [SerializeField] AudioClip punch;
    [SerializeField] AudioClip uppercutLeft;
    [SerializeField] AudioClip uppercutRight;
    [SerializeField] AudioClip hookLeft;
    [SerializeField] AudioClip hookRight;

    [SerializeField] AudioClip good;
    [SerializeField] AudioClip bad;

    [SerializeField] float punchMinPitch = 0.5f;
    [SerializeField] float punchMaxPitch = 1.5f;

    [SerializeField] AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPunch()
    {
        AudioClip clip = punches[Random.Range(0, punches.Length - 1)];
        source.clip = clip;
        source.pitch = Random.Range(punchMinPitch, punchMaxPitch);
        source.Play();
    }

    public void playMove(sensei_script.Move move)
    {
        //Switch on move, which should be done
        switch (move)
        {
            case sensei_script.Move.jab:
                source.clip = jab;
                source.pitch = 1.0f;
                source.Play();
                break;

            case sensei_script.Move.punch:
                source.clip = punch;
                source.pitch = 1.0f;
                source.Play(); 
                break;

            case sensei_script.Move.uppercutLeft:
                source.clip = uppercutLeft;
                source.pitch = 1.0f;
                source.Play();
                break;

            case sensei_script.Move.uppercutRight:
                source.clip = uppercutRight;
                source.pitch = 1.0f;
                source.Play();
                break;

            case sensei_script.Move.hookLeft:
                source.clip = hookLeft;
                source.pitch = 1.0f;
                source.Play();
                break;

            case sensei_script.Move.hookRight:
                source.clip = hookRight;
                source.pitch = 1.0f;
                source.Play();
                break;

            default:
                Debug.Log("Audio Ctrl: Unknown move");
                break;
        }
    }

    public void playGood()
    {
        source.clip = good;
        source.pitch = 1.0f;
        source.Play();
    }

    public void playBad()
    {
        source.clip = bad;
        source.pitch = 1.0f;
        source.Play();
    }
}
