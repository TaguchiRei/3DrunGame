using System.Net.Http.Headers;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Material[] material;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Type _shapeType;
    [SerializeField] Height _height;
    private void Start()
    {
        float X = transform.position.x;
        float Z = transform.position.z;
        if (_shapeType == Type.vertical)
        {
            transform.position = new Vector3 (X, 14.5f, Z);
        }
        else
        {
            float Y = 1.5f;
            if(_height ==Height.upper)
            {
                Y = 3;
            }
            transform.position = new Vector3(X, Y, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            meshRenderer.material = material[1];
            FindObjectOfType<GameManager>().HpFluctuation(15);
        }
    }
    enum Type
    {
        vertical,
        horizontal,
    }
    enum Height
    {
        upper,
        lower,
    }
}
