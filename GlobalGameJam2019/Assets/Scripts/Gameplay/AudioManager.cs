using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> m_footSteps = new List<AudioClip>();
    private List<AudioSource> m_footStepSources = new List<AudioSource>();

    public List<AudioClip> m_crabClicks = new List<AudioClip>();
    private List<AudioSource> m_crabClickSources = new List<AudioSource>();

    public List<AudioClip> m_glassSmashing = new List<AudioClip>();
    private List<AudioSource> m_glassSmashingSources = new List<AudioSource>();

    private void Start()
    {
        BuildAudioSources(m_footSteps, m_footStepSources);
        BuildAudioSources(m_crabClicks, m_crabClickSources);
        BuildAudioSources(m_glassSmashing, m_glassSmashingSources);
    }

    private void BuildAudioSources(List<AudioClip> p_currentClips, List<AudioSource> p_destinationList)
    {
        foreach (AudioClip audioClip in p_currentClips)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = audioClip;
            newAudioSource.loop = false;
            newAudioSource.playOnAwake = false;

            p_destinationList.Add(newAudioSource);
        }
    }

    public void PlayStep()
    {
        m_footStepSources[Random.Range(0, m_footStepSources.Count)].Play();
    }
    public void PlayCrabClick()
    {
        m_crabClickSources[Random.Range(0, m_crabClickSources.Count)].Play();
    }
    public void PlayGlassSmash()
    {
        m_glassSmashingSources[Random.Range(0, m_glassSmashingSources.Count)].Play();
    }
}
