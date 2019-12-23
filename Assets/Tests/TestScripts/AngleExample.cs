using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AngleExample : MonoBehaviour
{
    public Transform target;
    public LayerMask playerMask;
    Collider[] targetInRange;
    private Renderer rend;
    private float enemySpeed = 8.0f;

    private bool jestWZasiegu = false;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        Debug.Log("Kat: " + angle.ToString());
        if (angle > 90.0f)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        PlayerInRange();

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0.0f, 0.0f, enemySpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0.0f, 0.0f, -enemySpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(enemySpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-enemySpeed * Time.deltaTime, 0.0f, 0.0f);
        }
    }

    void PlayerInRange()
    {

        //targetInRange = Physics.OverlapSphere(transform.position, 5.0f, playerMask);
        targetInRange = Physics.OverlapSphere(transform.position, 5.0f);

        foreach (Collider visibleTarget in targetInRange)
        {
            if (visibleTarget.tag == "Player")
            {
                visibleTarget.transform.Rotate(new Vector3(0.0f, 15.0f * Time.deltaTime, 0.0f));
                rend.material.color = Color.black;
            }
            else
            {
                rend.material.color = Color.magenta;
            }
        }

    }
}
