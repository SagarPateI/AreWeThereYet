using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamControl : MonoBehaviour
{
    public Transform bckg1;
    public Transform bckg2;
    public float ms;
    public Transform target;

    private bool didstart = true;

    private float size;
    // Start is called before the first frame update
    void Start()
    {
        size = bckg1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y >= bckg2.position.y)
        {
            bckg1.position = new Vector3(bckg1.position.x, bckg2.position.y + size, bckg1.position.z);
            SwitchBckg();
        }

        if (transform.position.y < bckg1.position.y)
        {
            bckg2.position = new Vector3(bckg2.position.x, bckg1.position.y - size, bckg2.position.z);
            SwitchBckg();
        }
        if(didstart == true)
        {
            transform.Translate(Vector3.up * ms * Time.deltaTime);
        }
    }
    private void SwitchBckg()
    {
        Transform temp = bckg1;
        bckg1 = bckg2;
        bckg2 = temp;
    }
}
