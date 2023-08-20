using UnityEngine;

namespace Tanks
{
    public class AudioController : MonoBehaviour, IListener
    {
        [SerializeField] EventManager _eventManager;
        [SerializeField, Tooltip("��������� ������� � ���� ��� ��������� ����")]
        AudioSource _brickhitAudio;
        [SerializeField, Tooltip("����������� ����� ������")]
        AudioSource _explosionAudio;
        [SerializeField, Tooltip("����������� ����� ����������")]
        AudioSource _fexplosionAudio;
        [SerializeField, Tooltip("����� �� ������� �����")]
        AudioSource _gameoverAudio;
        [SerializeField, Tooltip("����� �������� ����")]
        AudioSource _levelstartingAudio;
        [SerializeField, Tooltip("�������� ����� ������")]
        AudioSource _movingAudio;
        [SerializeField, Tooltip("����� ��������� ������ � ������������ ���� � �������� ��������� ������")]
        AudioSource _nmovingAudio;
        [SerializeField, Tooltip("������� ESC � ������� �����")]
        AudioSource _pauseAudio;
        [SerializeField, Tooltip("������� �����")]
        AudioSource _shootAudio;
        [SerializeField, Tooltip("��������� � ����������� ������ ������������")]
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