using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HpObj = null;
    [SerializeField] float MaxHp = 50;
    float Hp = 20;
    bool _pause = true;
    public static bool start =false;
    float _goal = 0;
    private void Start()
    {
        Hp = MaxHp;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            PauseResume();
        }
        if(_goal > 0)
        {
            _goal -= Time.deltaTime;
            if(_goal < 0)
            {
                PauseResume();
                start = false;
                SceneManager.LoadScene("unitychanRun");
            }
        }
    }
    void PauseResume()
    {
        _pause = !_pause;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var o in objects)
        {
            IPause pause = o.GetComponent<IPause>();

            if (_pause)
            {
                pause.Resume();
            }else if(!_pause)
            {
                pause.Pause();
            }
        }
    }
    /// <summary>
    /// —^‚¦‚éƒ_ƒ[ƒW‚ğ•Ï”‚É“ü‚ê‚é
    /// </summary>
    /// <param name="Fluctuation"></param>
    public void HpFluctuation(float Fluctuation =0)
    {
        var H= HpObj.GetComponent<Image>();
        Hp -= Fluctuation;
        if(Hp <0)
        {
            PauseResume();
            start = false;
            SceneManager.LoadScene("unitychanRun");
        }
        else
        {
            H.DOFillAmount(Hp / MaxHp, 0.2f);
        }
    }
    public void Goal()
    {
        _goal = 5;
    }
}
