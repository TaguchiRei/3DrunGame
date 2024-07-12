using UnityEngine;

public class unitychanAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    float _time = 0;
    bool _change = true;
    bool _canMove = true;
    void Start()
    {
        anim.SetBool("jump", false);
        anim.SetBool("sliding", false);
        anim.SetBool("start", false);
        anim.SetBool("standBy", false);
        _time = 2;
    }

    // Update is called once per frame
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
            if(_canMove)
            {
                float LR = Input.GetAxisRaw("Horizontal");
                anim.SetInteger("LR", (int)LR * -1);
                if (Input.GetButtonDown("Jump"))
                {
                    _canMove = false;
                    anim.SetBool("Jump",true);
                }
                if(Input.GetKeyDown(KeyCode.LeftControl))
                {
                    _canMove = false;
                    anim.SetBool("sliding",true);
                }
            }
            else
            {
                anim.SetBool("Jump", false);
                anim.SetBool("sliding", false);

            }
        }

    }
}
