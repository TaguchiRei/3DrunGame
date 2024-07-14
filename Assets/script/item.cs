using UnityEngine;
/// <summary>
/// �A�C�e���̊�{�̓��������B
/// </summary>
public abstract class Item : MonoBehaviour, IPause
{
    //�ڐG���̉�
    [SerializeField] AudioClip _clip = default;
    [SerializeField] float _rotateSpeed = 1f;
    public bool _pause = false;
    public abstract void Use();
    private void Update()
    {
        if (!_pause)
        {
            transform.Rotate(0, Time.deltaTime * 60 * _rotateSpeed, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            Use();
            Destroy(gameObject);

        }
    }

    public void Pause()
    {
        _pause = true;
    }

    public void Resume()
    {
        _pause = false;
    }

}
