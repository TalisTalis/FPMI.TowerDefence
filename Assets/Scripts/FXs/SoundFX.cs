using UnityEngine;

namespace Assets.Scripts.FXs
{
    // аттрибут который гарантируетт что на объекте есть аудиосурс
    [RequireComponent(typeof(AudioSource))]
    public class SoundFX : MonoBehaviour
    {
        [SerializeField]
        private AudioClip m_AudioClip;

        [SerializeField, Range(-3,3)]
        private float m_MinPitch;
        [SerializeField, Range(-3,3)]
        private float m_MaxPitch;

        public void Awake()
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = m_AudioClip;
            audioSource.pitch = Random.Range(m_MinPitch, m_MaxPitch);

            audioSource.Play();
        }
    }
}
