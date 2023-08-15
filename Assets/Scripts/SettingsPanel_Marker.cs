using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPanel_Marker : MonoBehaviour
{
    [SerializeField] Button _return;

    private void OnEnable()
    {
        _return.onClick.AddListener(() => SceneManager.LoadScene(0));
    }

    private void OnDisable()
    {
        _return.onClick.RemoveListener(() => SceneManager.LoadScene(0));
    }
}
