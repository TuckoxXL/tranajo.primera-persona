using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.Find("Player");
    }

    public void comportamiento_enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {


            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 2)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
           

                case 0:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 1:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 2f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;

            }
        }
        else
        {
            var LookPos = target.transform.position - transform.position;
            LookPos.y = 0;
            var rotation = Quaternion.LookRotation(LookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

        }
    }

    private void Update()
    {
        comportamiento_enemigo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy get shooted");

            

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Shot>().Enemykilled();

        }
    }

    
}
