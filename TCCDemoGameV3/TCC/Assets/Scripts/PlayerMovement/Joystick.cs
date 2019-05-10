using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Joystick : MonoBehaviour
{
    //Definiçao da variavel velocidade
    public float velocidade;
    //Definiçao da Porta COM que sera utilizada
    SerialPort porta = new SerialPort("COM3", 9600);

    // Use this for initialization
    void Start()
    {
        //Abertura da Porta COM para conexao com o Arduino
        porta.Open();
        porta.ReadTimeout = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //Caso a porta COM responda positivamente estao executaremos o metodo Mover()
        if (porta.IsOpen)
        {
            try
            {
                Mover(porta.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
    }
    //Metodo Mover que sera chamado a cada clique no Push Button
    void Mover(int direcao)
    {
        //Para a Direita
        if (direcao == 1)
        {
            Debug.Log("1");
            transform.Translate(-Vector2.right * velocidade * Time.deltaTime, Space.World);
            //transform.Rotate(Vector3.up, -velocidade * Time.deltaTime);
        }
        //Para a Esquerda
        if (direcao == 0)
        {
            Debug.Log("0");
            transform.Translate(Vector2.right * velocidade * Time.deltaTime, Space.World);
            //transform.Rotate(Vector3.up, velocidade * Time.deltaTime);
        }

        if (direcao == 2)
        {
            Debug.Log("2");
            transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
        }
        //Para a Esquerda
        if (direcao == 3)
        {
            Debug.Log("3");
            transform.Translate(-Vector3.forward * velocidade * Time.deltaTime);
        }
    }
}