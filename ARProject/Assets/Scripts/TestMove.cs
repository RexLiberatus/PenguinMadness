using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    bool moveUp;
    Vector3 referencePosition;
    // Start is called before the first frame update
    void Start()
    {
        moveUp = true;
        referencePosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            if (transform.localPosition.y >= 10f)
            {
                transform.localPosition -= new Vector3(0, 1, 0) * Time.deltaTime;
                moveUp = false;
            }
            else
            {
                transform.localPosition += new Vector3(0, 1, 0) * Time.deltaTime;
            }
        }
        else
        {
            if (transform.localPosition.y <= -10f && !moveUp)
            {
                transform.localPosition += new Vector3(0, 1, 0) * Time.deltaTime;
                moveUp = true;
            }
            else
            {
                transform.localPosition -= new Vector3(0, 1, 0) * Time.deltaTime;
            }
        }
    }
}
