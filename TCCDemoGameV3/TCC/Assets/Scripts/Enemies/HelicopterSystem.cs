using System;
using Unity.Entities;
using UnityEngine;

public class HelicopterSystem : ComponentSystem
{

    public struct Filter
    {
        public Transform transform;
        public HelicopterComponent HelicopterComponent;
    }

    protected override void OnUpdate()
    {
        try
        {
            foreach (var entity in GetEntities<Filter>())
            {
                //Efeito da aproximação dos Inimigos
                entity.HelicopterComponent.transform.localScale += new Vector3(1, 1, 0) * Time.deltaTime * entity.HelicopterComponent.speed;
                entity.HelicopterComponent.tamanho++;

                if (entity.HelicopterComponent.tamanho >= 300)
                {
                    AudioManagerScript.Instance.PlayExplosionSound();
                    GameObject.Destroy(entity.HelicopterComponent.gameObject);
                    Score.Instance.Damage += 1;
                }

            }
        }
        catch (Exception ex)
        {
            Debug.Log("Erro ao acessar a entidade");
        }

    }
}
