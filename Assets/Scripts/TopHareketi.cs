using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareketi : MonoBehaviour
{
    Vector3 y�n;
    public float h�z;
    public ZeminSpawner zeminspawnerscripti;
    public static bool d��t�_m�;
    public float eklenecek_h�z;

    void Start()
    {
        y�n = Vector3.forward;
        d��t�_m� = false;
    }


    void Update()
    {
        if(transform.position.y<= 0.5f)
        {
            d��t�_m� = true;
        }
        if(d��t�_m� == true)
        {
            Debug.Log("d��t�m");
            return;
        }

        /* i�te kuzu kuzu geldim 
        diledi�ince kapand�m dizlerine .
        bu kez gururumu 
        ate�e verdim yakt�m da geldim
         */

        if (Input.GetMouseButtonDown(0)) //0 sol tu� 1 sa� tu�;)
        {
            if (y�n.x == 0)
            {
                y�n = Vector3.left;
            }
            else
            {
                y�n = Vector3.forward;
            }
            h�z += eklenecek_h�z * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = y�n * Time.deltaTime * h�z;
        transform.position += hareket;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            Skor.skor++;
            collision.gameObject.AddComponent<Rigidbody>();
            zeminspawnerscripti.zemin_olu�tur();
            StartCoroutine(ZeminiSil(collision.gameObject));
        }
    }

    IEnumerator ZeminiSil(GameObject SilinecekZemin)
    {
        yield return new WaitForSeconds(3f);
        Destroy(SilinecekZemin);
    }
}
