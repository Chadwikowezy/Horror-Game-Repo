using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource objectSounds;
    public AudioSource playerSteps;
    public AudioSource rain_Ambience;
    public AudioSource breath_Heartbeat;
    public AudioSource phoneSounds;
    public AudioSource insanitySounds;
    public AudioSource spectorSounds;
    public AudioSource levelToneSounds;

    public List<AudioClip> playerStepClips = new List<AudioClip>();
    public List<AudioClip> objectSoundClips = new List<AudioClip>();
    public List<AudioClip> phoneSoundClips = new List<AudioClip>();
    public List<AudioClip> spectorSoundClips = new List<AudioClip>();
    public List<AudioClip> insanitySoundClips = new List<AudioClip>();
    public List<AudioClip> levelToneSoundClips = new List<AudioClip>();

    private bool playRandomToneClip = true;

	public void StepsBegin()
    {
        playerSteps.Play();
    }
    public void StepsStop()
    {
        playerSteps.Stop();
    }

    public void ObjectBegin(int clipNumber)
    {
        objectSounds.clip = objectSoundClips[clipNumber];
        objectSounds.Play();
    }

    public void phoneBeginSound(int clipNumber)
    {
        phoneSounds.clip = phoneSoundClips[clipNumber];      
        phoneSounds.Play();
    }

    public void SpectorBeginSound(int clipNumber)
    {
        spectorSounds.clip = spectorSoundClips[clipNumber];        
        spectorSounds.Play();
    }

    public void InsanityBreaking(int clipNumber)
    {
        insanitySounds.clip = insanitySoundClips[clipNumber];
        if(clipNumber == 0)
        {
            insanitySounds.volume = .45f;
        }
        else if(clipNumber == 1)
        {
            insanitySounds.volume = 1f;
        }
        insanitySounds.Play();
    }

    public void LevelToneSounds()
    {
        StartCoroutine(PlayARandomToneClip());
    }
    IEnumerator PlayARandomToneClip()
    {
        playRandomToneClip = false;
        int clipValue = Random.Range(0, levelToneSoundClips.Count);
        Debug.Log("clip val:" + clipValue);
        levelToneSounds.clip = levelToneSoundClips[clipValue];
        levelToneSounds.Play();

        int waitLength = Random.Range(40, 121);
        yield return new WaitForSeconds(waitLength);
        playRandomToneClip = true;
    }

    void Update()
    {
        if(playRandomToneClip == true)
        {
            LevelToneSounds();
        }
    }
}
