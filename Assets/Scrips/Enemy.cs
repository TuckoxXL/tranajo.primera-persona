using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animation ani;
    public Quaternion angulo;
    public float grado;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
    }

    public void comportamiento_enemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        
        switch (rutina)
        {
          case 0:
                ani.Stop("Walk");
                break;

          case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;

            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                break;

        }
    }

    private void Update()
    {
        comportamiento_enemigo();
    }
}
