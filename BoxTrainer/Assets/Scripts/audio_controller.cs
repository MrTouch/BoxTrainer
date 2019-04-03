using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_controller : MonoBehaviour
{
    [SerializeField] AudioSource[] punches;

    [SerializeField] AudioSource jab;
    [SerializeField] AudioSource punch;
    [SerializeField] AudioSource uppercutLeft;
    [SerializeField] AudioSource uppercutRight;
    [SerializeField] AudioSource hookLeft;
    [SerializeField] AudioSource hookRight;

    [SerializeField] AudioSource good;
    [SerializeField] AudioSource bad;

    [SerializeField] float punchMinPitch;
    [SerializeField] float punchMaxPitch;

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
        AudioSource punch = punches[Random.Range(0, punches.Length-1)];
        punch.pitch = Random.Range(punchMinPitch, punchMaxPitch);
        punch.Play();
    }

    public void playMove(sensei_script.Move move)
    {
        //Switch on move, which should be done
        switch (move)
        {
            case sensei_script.Move.jab:
                jab.Play();
                break;

            case sensei_script.Move.punch:
                punch.Play();
                break;

            case sensei_script.Move.uppercutLeft:
                uppercutLeft.Play();
                break;

            case sensei_script.Move.uppercutRight:
                uppercutRight.Play();
                break;

            case sensei_script.Move.hookLeft:
                hookLeft.Play(),
                break;

            case sensei_script.Move.hookRight:
                hookRight.Play();
                break;

            default:
                Debug.Log("Audio Ctrl: Unknown move");
                break;
        }
    }

    public void playGood()
    {
        good.Play();
    }

    public void playBad()
    {
        bad.Play();
    }
}
