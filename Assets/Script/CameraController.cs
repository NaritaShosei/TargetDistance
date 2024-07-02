using UnityEngine;
public class CameraController : MonoBehaviour
{
    Transform _target;  // �v���C���[��Transform
    [SerializeField] Vector3 _offset;  // �v���C���[�ƃJ�����̑��Έʒu = ���S�ɉf�������Ƃ��͎g��Ȃ�
    private void Start()
    {
        Invoke("GetTransform", 0);
    }
    void LateUpdate()
    {

    }
    void GetTransform()
    {
        _target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        Debug.Log("GetCom");
        // �v���C���[�̈ʒu�ɃJ������Ǐ]������
        if (_target != null)
        {
            transform.position = new Vector3(transform.position.x, _target.position.y + _offset.y, transform.position.z);
        }

        if (_target == null)
        {
            this.gameObject.transform.parent = null;
        }
    }
}