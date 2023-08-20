using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class Config_Controller : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> _audioSources;

        private void Start()
        {
            foreach (AudioSource source in _audioSources)
            {
                source.volume = (float)GameConfiguration.SoundVolume / 100;
            }
        }
    }
}