using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HpObj = null;
    [SerializeField] float MaxHp = 50;
    float Hp = 20;
    bool _pause = true;
    public static bool start =false;
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
    /// ó^Ç¶ÇÈÉ_ÉÅÅ[ÉWÇïœêîÇ…ì¸ÇÍÇÈ
    /// </summary>
    /// <param name="Fluctuation"></param>
    public void HpFluctuation(float Fluctuation =0)
    {
        var H= HpObj.GetComponent<Image>();
        Hp -= Fluctuation;
        H.DOFillAmount(Hp/MaxHp,0.2f);
    }
}
