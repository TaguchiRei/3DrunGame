using UnityEngine;

public class PlayerMove2 : MonoBehaviour,IPause
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] CapsuleCollider _capsuleCollider;
    [SerializeField] float _speed = 1;
    [SerializeField] float _buff = 1;
    [SerializeField] float _jumpP = 1;
    Vector3 localGravity = new Vector3(0, 9.81f, 0);
    Vector3 _pauseSave;
    float _jumpSlideTime;
    bool _pause = false;
    bool _canMove = false;
    
    private void Update()
    {
        if (GameManager.start)
        {
            if (!_pause)
            {
                //左右と高さの動き
                float LR = 0;
                float Y = _rb.velocity.y;
                if (_canMove)
                {
                    LR = Input.GetAxisRaw("Horizontal");
                    if (Input.GetButtonDown("Jump"))
                    {
                        Y = _jumpP;
                        _canMove = false;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftControl))
                    {
                        _canMove = false;
                        _jumpSlideTime = 1.5f;
                        _buff = 1.5f;
                        _capsuleCollider.center = new Vector3 (0,0.27f,0);
                        _capsuleCollider.height = 0.3f;
                    }
                }
                _rb.velocity = new Vector3(_speed * _buff * -1, Y, LR * _speed / 1.5f);

                if(_jumpSlideTime > 0)
                {
                    _jumpSlideTime -= Time.deltaTime;
                    if (_jumpSlideTime < 0 )
                    {
                        _buff = 1;
                        PlayerCanMove();
                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpSlideTime = 0.4f;
            FindObjectOfType<UnitychanAnimation>().Canmove();
        }
    }
    /// <summary>
    /// プレイヤーのスライディング、ジャンプの硬直が終わるときに呼び出される
    /// </summary>
    void PlayerCanMove()
    {
        _capsuleCollider.center = new Vector3(0, 0.75f, 0);
        _capsuleCollider.height = 1.5f;
        _canMove = true;
        FindObjectOfType<UnitychanAnimation>().Canmove();
    }
    /// <summary>
    /// 重力を管理
    /// </summary>
    private void FixedUpdate()
    {
        if (!_pause)
        {
            if (_rb.velocity.y < 0.05f)
            {
                localGravity.y = -40;
            }
            else
            {
                localGravity.y = -9.81f;
            }
            _rb.AddForce(localGravity, ForceMode.Acceleration);
        }
    }
    /// <summary>
    /// ポーズとその周辺の速度を管理
    /// </summary>
    public void Pause()
    {
        _pauseSave = _rb.velocity;
        _rb.velocity = Vector3.zero;
        _pause = true;
    }

    public void Resume()
    {
        _pause = false;
        _rb.velocity = _pauseSave;
    }
}
