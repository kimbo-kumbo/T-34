using UnityEngine;

namespace Tanks
{
    public class AudioController : MonoBehaviour, IListener
    {
        [SerializeField] EventManager _eventManager;
        [SerializeField, Tooltip("попадание снаряда в блок или вражеский танк")]
        AudioSource _brickhitAudio;
        [SerializeField, Tooltip("уничтожение танка игрока")]
        AudioSource _explosionAudio;
        [SerializeField, Tooltip("уничтожение танка противника")]
        AudioSource _fexplosionAudio;
        [SerializeField, Tooltip("выход из игровой сцены")]
        AudioSource _gameoverAudio;
        [SerializeField, Tooltip("старт игрового меню")]
        AudioSource _levelstartingAudio;
        [SerializeField, Tooltip("движение танка игрока")]
        AudioSource _movingAudio;
        [SerializeField, Tooltip("игрок упирается танком в непроходимый блок и пытается двигаться дальше")]
        AudioSource _nmovingAudio;
        [SerializeField, Tooltip("нажатие ESC в игровой сцене")]
        AudioSource _pauseAudio;
        [SerializeField, Tooltip("выстрел танка")]
        AudioSource _shootAudio;
        [SerializeField, Tooltip("активация и деактивация режима неуязвимости")]
        AudioSource _tbonushitAudio;

        private void Start()
        {
            _eventManager.AddListener(EventType.Brickhit, this);
            _eventManager.AddListener(EventType.Explosion, this);
            _eventManager.AddListener(EventType.Fexplosion, this);
            _eventManager.AddListener(EventType.Gameover, this);
            _eventManager.AddListener(EventType.Levelstarting, this);
            _eventManager.AddListener(EventType.Moving, this);
            _eventManager.AddListener(EventType.Nmoving, this);
            _eventManager.AddListener(EventType.Pause, this);
            _eventManager.AddListener(EventType.Shoot, this);
            _eventManager.AddListener(EventType.Tbonushit, this);
        }

        public void OnEvent(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Brickhit: _brickhitAudio.Play(); break;
                case EventType.Explosion: _explosionAudio.Play(); break;
                case EventType.Fexplosion: _fexplosionAudio.Play(); break;
                case EventType.Gameover: _gameoverAudio.Play(); break;
                case EventType.Levelstarting: _levelstartingAudio.Play(); break;
                case EventType.Moving: _movingAudio.Play(); break;
                case EventType.Nmoving: _nmovingAudio.Play(); break;
                case EventType.Pause: _pauseAudio.Play(); break;
                case EventType.Shoot: _shootAudio.Play(); break;
                case EventType.Tbonushit: _tbonushitAudio.Play(); break;
            }
        }
    }
}