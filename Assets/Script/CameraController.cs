using UnityEngine;
public class CameraController : MonoBehaviour
{
    Transform _target;  // プレイヤーのTransform
    [SerializeField] Vector3 _offset;  // プレイヤーとカメラの相対位置 = 中心に映したいときは使わない
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
        // プレイヤーの位置にカメラを追従させる
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