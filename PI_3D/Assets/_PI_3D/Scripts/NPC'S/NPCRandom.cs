using System.Collections;
using UnityEngine;

public class NPCRandom : MonoBehaviour
{
    public float velMov, velRot;

    public float tiempoReaccion = 0.8f; 
    int movimiento;
    bool espera, camina, gira;

    private void Start()
    {
        accion();
    }

    private void Update()
    {
        if (espera)
        {
            GetComponent<Animator>().SetBool("activo", false);
        }
        if (camina)
        {
            GetComponent<Animator>().SetBool("activo", true);
            transform.position += (transform.forward * velMov * Time.deltaTime);
        }
        if (gira)
        {
            transform.Rotate(Vector3.up * velRot * Time.deltaTime);
        }
    }

    void accion()
    {
        movimiento = Random.Range(1, 4);

        if(movimiento == 1)
        {
           espera = true;
            camina = false;  
        }
        if(movimiento == 2)
        {
            camina = true;
            espera = false;
        }
        if(movimiento == 3)
        {
            gira = true;
            StartCoroutine(tiempoGiro());
        }

        Invoke("accion", tiempoReaccion);
    }


    IEnumerator tiempoGiro()
    {
        yield return new WaitForSeconds(2);
        gira = true;
    }
}
