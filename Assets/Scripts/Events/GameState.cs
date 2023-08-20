using UnityEngine;

namespace Tanks
{
    public class GameState : MonoBehaviour
    {
        private static GameStateType _gameStateType;
        public static GameStateType GameStateType => _gameStateType;

        private void Start()
        {
            _gameStateType = GameStateType.StartGame;
            _gameStateType = GameStateType.PlayGame;
        }

        public void ChangeGameState(bool isPlay)
        {
            if (isPlay) _gameStateType = GameStateType.PlayGame;
            else _gameStateType = GameStateType.PauseGame;
        }
    }

    public enum GameStateType
    {
        StartGame,
        PlayGame,
        PauseGame
    }
}
