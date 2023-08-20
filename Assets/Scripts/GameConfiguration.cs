using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks
{
    public class GameConfiguration : MonoBehaviour
    {
        private static int _soundVolume;
        private static int _livePlayer;
        private static int _liveEnemy;
        private static int _countEnemy;
        private static GameConfiguration _instance = null;
        public static GameConfiguration Instance => _instance;

        public static int SoundVolume { get => _soundVolume; set { if (GetSceneIndex() == 0) _soundVolume = value; } }
        public static int LivePlayer { get => _livePlayer; set { if (GetSceneIndex() == 0) _livePlayer = value; } }
        public static int LiveEnemy { get => _liveEnemy; set { if (GetSceneIndex() == 0) _liveEnemy = value; } }
        public static int CountEnemy { get => _countEnemy; set { if (GetSceneIndex() == 0) _countEnemy = value; } }

        private static int GetSceneIndex()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }

        private void Awake()
        {
            if (_instance)
            {
                DestroyImmediate(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}