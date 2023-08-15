using UnityEngine;
using UnityEngine.UI;

public class StartMenu_Controller : BaseUI_Controller
{
    [SerializeField] private Button _newGame;  
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;    
    [SerializeField] private StartPanel_Marker _startPanel;
    [SerializeField] private SettingsPanel_Marker _settingsPanel;

    private void OnEnable()
    {
        _newGame.onClick.AddListener(delegate { LoadScene(SceneExample.NewGame); });       
        _settings.onClick.AddListener(delegate { LoadSettings(); });
        _exit.onClick.AddListener(delegate { LoadScene(SceneExample.Exit); });        
    }

    private void OnDisable()
    {
        _newGame.onClick.RemoveListener(delegate { LoadScene(SceneExample.NewGame); });      
        _settings.onClick.RemoveListener(delegate { LoadSettings(); });
        _exit.onClick.RemoveListener(delegate { LoadScene(SceneExample.Exit); });
    }
    private void LoadSettings() //��������
    {
        _startPanel.gameObject.SetActive(false);
        _settingsPanel.gameObject.SetActive(true);
    }
}
