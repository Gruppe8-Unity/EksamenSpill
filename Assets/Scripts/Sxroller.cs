using UnityEngine;

public class Sxroller : MonoBehaviour
{
    public float scrollSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        //bevege nedover
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        //ødelegge tile når den er av skjermen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }

    }
}
