using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks
{
    public class MenuController : BaseUI_Controller , IListener
    {
        private EventManager _eventManager;
        [SerializeField] private PauseMenuPanel _pauseMenuPanel;
        [SerializeField] private GameOverPanel gameoverPanel;
        [SerializeField] private GameState _gameState;
        private bool _isActive = false;

        private void Start()
        {
            _eventManager = FindObjectOfType<EventManager>();
            _eventManager.AddListener(EventType.Gameover, this);
        }
        public void OnPause()
        {
            _isActive = !_isActive;
            _pauseMenuPanel.gameObject.SetActive(_isActive);
            if (_isActive) _gameState.ChangeGameState(false);
            else _gameState.ChangeGameState(true);
        }

        public void OnEvent(EventType eventType)
        {
            gameoverPanel.gameObject.SetActive(true);
            Invoke("EndGame", 3f);
        }

        public void EndGame()
        {
            SceneManager.LoadScene(0);
        }        
    }
}