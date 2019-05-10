using System;
using System.IO.Ports;
using Unity.Entities;
using UnityEngine;

public class PlayerInputSystem : ComponentSystem {

    public SerialPort porta = new SerialPort("COM3", 9600);
    public static bool isGloves;
    public bool isAttacking;

    private struct Filter
    {
        public PlayerInputComponent PlayerInputComponent;
        public Transform Transform;
    }

    public PlayerInputSystem()
    {
        if (!porta.IsOpen)
        {
            try
            {
                porta.Open();
                porta.ReadTimeout = 100;
                isGloves = true;
            }
            catch (Exception ex)
            {
                Debug.Log("Teclado manual");
            }
        }
    }

    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Filter>())
        {
            if (isGloves)
            {
                try
                {
                    if (porta.ReadByte() == 4)
                    {
                        isAttacking = true;
                        Debug.Log(porta.ReadByte());
                    }
                    else
                    {
                        entity.PlayerInputComponent.direction = porta.ReadByte();
                        isAttacking = false;
                    }
                }
                catch (Exception ex)
                {
                    //Debug.Log(ex.Message);
                }
            }
            else
            {
                entity.PlayerInputComponent.horizontal = Input.GetAxis("Horizontal");
                entity.PlayerInputComponent.vertical = Input.GetAxis("Vertical");
                isAttacking = Input.GetKey(KeyCode.Space);
            }

            //Controle de disparos
            if (isAttacking)
            {
                AudioManagerScript.Instance.isAttacking = true;
                entity.PlayerInputComponent.img_Fire.color = new Color(255, 255, 255, 255);
                GameObject.FindGameObjectWithTag("alvo").GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                AudioManagerScript.Instance.isAttacking = false;
                entity.PlayerInputComponent.img_Fire.color = new Color(255, 255, 255, 0);
                GameObject.FindGameObjectWithTag("alvo").GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
