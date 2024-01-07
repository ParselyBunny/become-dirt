using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class Billboard : MonoBehaviour
{
    private Transform _targetTf;

    void OnEnable()
    {
        _targetTf = Camera.main.transform;
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public Vector3 lookAt;
    void LateUpdate()
    {
        lookAt.x = _targetTf.position.x;
        lookAt.y = transform.position.y;
        lookAt.z = _targetTf.position.z;
        transform.LookAt(
            2 * transform.position - lookAt
        );
    }
}