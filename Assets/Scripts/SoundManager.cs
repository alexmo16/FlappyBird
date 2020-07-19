using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager m_instance = null;

    [SerializeField]
    private AudioSource m_efxSource = null;
    [SerializeField]
    private AudioSource m_musicSource = null;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip_, float volume_ = 1f)
    {
        m_efxSource.clip = clip_;
        m_efxSource.volume = volume_;
        m_efxSource.Play();
    }

    public void StopMusic()
    {
        m_musicSource.Stop();
    }
}
