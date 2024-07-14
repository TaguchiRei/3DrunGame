using UnityEngine;

public class UnitychanAnimation : MonoBehaviour, IPause
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject player;
    float _time = 0;
    float _animTime = 0;
    float _animSlow = 0;
    float _animSpeedSave = 0;
    bool _change = true;
    bool _canMove = true;
    bool _pause = false;
    bool _canJumpSlide = true;
    void Start()
    {
        anim.SetBool("jump", false);
        anim.SetBool("sliding", false);
        anim.SetBool("start", false);
        anim.SetBool("standBy", false);
        _time = 2;
        anim.speed = 1.2f;
    }

    void Update()
    {
        if (!GameManager.start)
        {
            if (_time < 0)
            {
                anim.SetBool("standBy", _change);
                _change = !_change;
                _time = 1;
            }
            _time -= Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                GameManager.start = true;
                anim.SetBool("start", true);
            }
        }
        else
        {
            if (!_pause)
            {
                if (_canMove)
                {
                    float LR = Input.GetAxisRaw("Horizontal");
                    anim.SetInteger("LR", (int)LR * -1);
                    if (Input.GetButtonDown("Jump") && _canJumpSlide)
                    {
                        _canJumpSlide = false;
                        _animTime = 1f;
                        _animSlow = 0.2f;
                        anim.speed = 1.5f;
                        _canMove = false;
                        anim.SetBool("jump", true);
                    }
                    if (Input.GetKeyDown(KeyCode.LeftControl) && _canJumpSlide)
                    {
                        _canMove = false;
                        _canJumpSlide = false ;
                        anim.SetBool("sliding", true);
                    }
                }
                else
                {
                    anim.SetBool("jump", false);
                    anim.SetBool("sliding", false);
                    //アニメーションを遅くする
                    if (_animTime > 0)
                    {
                        _animTime -= Time.deltaTime;
                        _animSlow -= Time.deltaTime;
                        if (_animTime < 0)
                        {
                            anim.speed = 0;
                        }
                    }
                    if (_animSlow < 0)
                    {
                        anim.speed -= 0.2f;
                        _animSlow = 0.15f;
                    }
                }
            }
        }

    }
    private void FixedUpdate()
    {
        if (!_pause)
        {
            transform.position = player.transform.position;
        }
    }

    public void Canmove()
    {
        _canJumpSlide = true ;
        _canMove = true;
        anim.speed = 1.2f;
    }

    public void Pause()
    {
        _animSpeedSave = anim.speed;
        _pause = true;
        anim.speed = 0;
    }

    public void Resume()
    {
        anim.speed = _animSpeedSave;
        _pause = false;
    }
}
