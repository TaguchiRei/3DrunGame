using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;

    Vector3 currentPos;//���݂̃J�����ʒu
    Vector3 pastPos;//�ߋ��̃J�����ʒu

    Vector3 diff;//�ړ�����

    private void Start()
    {
        //�ŏ��̃v���C���[�̈ʒu�̎擾
        pastPos = player.transform.position;
    }
    void Update()
    {
        if (!GameManager.pause)
        {
            //------�J�����̈ړ�------

            //�v���C���[�̌��ݒn�̎擾
            currentPos = player.transform.position;

            diff = currentPos - pastPos;

            transform.position = Vector3.Lerp(transform.position, transform.position + diff, 1.0f);//�J�������v���C���[�̈ړ�������������������

            pastPos = currentPos;


            //------�J�����̉�]------

            // �}�E�X�̈ړ��ʂ��擾
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            // X�����Ɉ��ʈړ����Ă���Ή���]
            if (Mathf.Abs(mx) > 0.01f)
            {
                // ��]���̓��[���h���W��Y��
                transform.RotateAround(player.transform.position, Vector3.up, mx);
            }

            // Y�����Ɉ��ʈړ����Ă���Ώc��]
            if (Mathf.Abs(my) > 0.01f)
            {
                // ��]���̓J�������g��X��
                transform.RotateAround(player.transform.position, transform.right, -my);
            }
        }
    }

}