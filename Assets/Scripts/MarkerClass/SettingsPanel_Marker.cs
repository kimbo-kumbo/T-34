using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tanks
{
    public class SettingsPanel_Marker : MonoBehaviour
    {
        [SerializeField] Button _return;
        [SerializeField] Slider _sliderSoundVolume;
        [SerializeField] Slider _sliderLivePlayer;
        [SerializeField] Slider _sliderLiveEnemy;
        [SerializeField] Slider _sliderCountEnemy;
        [SerializeField] TextMeshProUGUI _soundVolume;
        [SerializeField] TextMeshProUGUI _livePlayer;
        [SerializeField] TextMeshProUGUI _liveEnemy;
        [SerializeField] TextMeshProUGUI _countEnemy;

        private void OnEnable()
        {
            _return.onClick.AddListener(() => SceneManager.LoadScene(0));                       
        }

        private void OnDisable()
        {
            _return.onClick.RemoveListener(() => SceneManager.LoadScene(0));
        }

        public void ConvertSliderValueFromText(Slider slider)
        {
            if (slider == null) return;

            if (slider == _sliderSoundVolume)
            {
                GameConfiguration.SoundVolume = (int)slider.value;
                _soundVolume.text = slider.value.ToString();
            }
            else if (slider == _sliderLivePlayer)
            {
                GameConfiguration.LivePlayer = (int)slider.value;
                _livePlayer.text = slider.value.ToString();
            }
            else if (slider == _sliderLiveEnemy)
            {
                GameConfiguration.LiveEnemy = (int)slider.value;
                _liveEnemy.text = slider.value.ToString();
            }
            else if (slider == _sliderCountEnemy)
            {
                GameConfiguration.CountEnemy = (int)slider.value;
                _countEnemy.text = slider.value.ToString();
            }
        }
    }
}
