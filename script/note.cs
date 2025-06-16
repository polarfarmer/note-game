using UnityEngine;

public class note : MonoBehaviour
{
    public float fallSpeed = 10f;
    // Update is called once per frame
    void Update()
    {   
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        if(transform.position.y > 10f) {
            transform.position += Vector3.up * fallSpeed * Time.deltaTime;
        }
        if(transform.position.y < -10f) {
            Destroy(gameObject);
        }
    }
}
