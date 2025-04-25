using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_controller : MonoBehaviour
{
    [SerializeField] private GameObject Game_win_screen;
    [SerializeField] private GameObject Play_menu;
    [SerializeField] private RectTransform Setting_button;
    [SerializeField, Range(0f, 1f)] private float setting_anime_speed = 0.1f;
    [SerializeField] private GameObject Volume_btn_on;
    [SerializeField] private GameObject Volume_btn_off;
    [SerializeField] private GameObject Audio_cont_obj;
    [SerializeField] private GameObject Pause_menu;

    private GameObject Current_menu_opend;
    private bool is_setting_on = false;
    private Vector2 setting_new_pos;
    private Vector2 setting_og_pos;
    private bool was_paused = false;

    void Start()
    {
        Current_menu_opend = Play_menu;
        //setting_og_pos = Setting_button.localPosition;
        //setting_new_pos = setting_og_pos + new Vector2(0f, -92f);
    }

    void Update()
    {
        //AnimateSettingButton();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        if (!Pause_menu.activeInHierarchy && was_paused)
        {
            Time.timeScale = 1f;
            was_paused = false;
        }
    }

    // UI Actions
    public void Start_Game()
    {
        Play_menu.SetActive(false);
        Current_menu_opend = null;
    }

    public void Close_current_menu()
    {
        if (Current_menu_opend != null)
            Current_menu_opend.SetActive(false);
        Current_menu_opend = null;
    }

    public void Open_Settings()
    {
        is_setting_on = !is_setting_on;
    }

    private void AnimateSettingButton()
    {
        if (is_setting_on)
        {
            Setting_button.gameObject.SetActive(true);
            Setting_button.localPosition = Vector2.Lerp(Setting_button.localPosition, setting_new_pos, setting_anime_speed);
            Setting_button.sizeDelta = Vector2.Lerp(Setting_button.sizeDelta, new Vector2(Setting_button.sizeDelta.x, 300), setting_anime_speed);
        }
        else
        {
            Setting_button.localPosition = Vector2.Lerp(Setting_button.localPosition, setting_og_pos, setting_anime_speed);
            Setting_button.sizeDelta = Vector2.Lerp(Setting_button.sizeDelta, new Vector2(Setting_button.sizeDelta.x, 120), setting_anime_speed);

            if (Vector2.Distance(Setting_button.localPosition, setting_og_pos) < 0.1f)
            {
                Setting_button.gameObject.SetActive(false);
            }
        }
    }

    public void Mute_volume()
    {
        Volume_btn_on.SetActive(true);
        Volume_btn_off.SetActive(false);
        Audio_cont_obj.SetActive(false);
    }

    public void Unmute_volume()
    {
        Volume_btn_on.SetActive(false);
        Volume_btn_off.SetActive(true);
        Audio_cont_obj.SetActive(true);
    }

    public void Exit_button()
    {
        Application.Quit();
    }

    public void TogglePauseMenu()
    {
        if (Pause_menu.activeInHierarchy)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
            Pause_menu.SetActive(false);
            Time.timeScale = 1f;
            was_paused = false;
        }
        else
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            Pause_menu.SetActive(true);
            Time.timeScale = 0f;
            was_paused = true;
            Current_menu_opend = Pause_menu;
        }
    }

    public void Next_Level()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == PlayerPrefs.GetInt("Current_Level"))
        {
            PlayerPrefs.SetInt("Current_Level", currentScene + 1);
        }

        SceneManager.LoadScene(currentScene + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("is_Using_level_menu", "false");
    }

    public void GameWin()
    {
        // Game_win_screen.SetActive(true);
    }
}