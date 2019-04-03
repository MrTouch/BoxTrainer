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

    [SerializeField] AudioClip[] good;
    [SerializeField] AudioClip[] bad;

    [SerializeField] float punchMinPitch = 0.5f;
    [SerializeField] float punchMaxPitch = 1.5f;

    [SerializeField] AudioSource sourceVoice;
    [SerializeField] AudioSource sourceSFX;

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
        AudioClip clip = punches[Random.Range(0, punches.Length)];
        sourceSFX.clip = clip;
        sourceSFX.pitch = Random.Range(punchMinPitch, punchMaxPitch);
        sourceSFX.Play();
    }

    public void playMove(sensei_script.Move move)
    {
        //Switch on move, which should be done
        switch (move)
        {
            case sensei_script.Move.jab:
                sourceVoice.clip = jab;
                sourceVoice.pitch = 1.0f;
                sourceVoice.Play();
                break;

            case sensei_script.Move.punch:
                sourceVoice.clip = punch;
                sourceVoice.pitch = 1.0f;
                sourceVoice.Play(); 
                break;

            case sensei_script.Move.uppercutLeft:
                sourceVoice.clip = uppercutLeft;
                sourceVoice.pitch = 1.0f;
                sourceVoice.Play();
                break;

            case sensei_script.Move.uppercutRight:
                sourceVoice.clip = uppercutRight;
                sourceVoice.pitch = 1.0f;
                sourceVoice.Play();
                break;

            case sensei_script.Move.hookLeft:
                sourceVoice.clip = hookLeft;
                sourceVoice.pitch = 1.0f;
                sourceVoice.Play();
                break;

            case sensei_script.Move.hookRight:
                sourceVoice.clip = hookRight;
                sourceVoice.pitch = 1.0f;
                sourceVoice.Play();
                break;

            default:
                Debug.Log("Audio Ctrl: Unknown move");
                break;
        }
    }

    public void playGood()
    {
        AudioClip clip = good[Random.Range(0, good.Length)];
        sourceVoice.clip = clip;
        sourceVoice.pitch = 1.0f;
        sourceVoice.Play();
    }

    public void playBad()
    {
        AudioClip clip = bad[Random.Range(0, bad.Length)];
        sourceVoice.clip = clip;
        sourceVoice.pitch = 1.0f;
        sourceVoice.Play();
    }
}
