using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_loader_menue : MonoBehaviour
{
    [SerializeField] private float delaycount;
    private float delaycounttemp;

    private void Start() {
        delaycounttemp = delaycount;
    }
    
    void Update()
    {
        if (delaycount <= 0 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        delaycount -= Time.deltaTime;
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void LevelMenuBtn()
    {
        SceneManager.LoadScene(1);
    }
}
