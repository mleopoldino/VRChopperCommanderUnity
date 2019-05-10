using Unity.Entities;
using UnityEngine;

public class PlayerMovementSystem : ComponentSystem {

    private struct Filter
    {
        public Transform Transform;
        public PlayerInputComponent PlayerInputComponent;
    }

    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Filter>())
        {
            if (PlayerInputSystem.isGloves)
            {
                //sincronizando movimentos da luva com os movimentos da aeronave
                if (entity.PlayerInputComponent.direction == 0)
                {
                    entity.PlayerInputComponent.vertical = 1;
                    entity.PlayerInputComponent.horizontal = 0;
                }

                if (entity.PlayerInputComponent.direction == 1)
                {
                    entity.PlayerInputComponent.vertical = -1;
                    entity.PlayerInputComponent.horizontal = 0;
                }

                if (entity.PlayerInputComponent.direction == 2)
                {
                    entity.PlayerInputComponent.horizontal = 1;
                    entity.PlayerInputComponent.vertical = 0;
                }

                if (entity.PlayerInputComponent.direction == 3)
                {
                    entity.PlayerInputComponent.horizontal = -1;
                    entity.PlayerInputComponent.vertical = 0;
                }
            }

            //Movimentação da camera - Limites
            if (entity.PlayerInputComponent.horizontal > 0 && entity.Transform.position.x > 9.8f)
                return;

            if (entity.PlayerInputComponent.horizontal < 0 && entity.Transform.position.x < -9.8f)
                return;

            if (entity.PlayerInputComponent.vertical > 0 && entity.Transform.position.y > 9.5f)
                return;

            if (entity.PlayerInputComponent.vertical < 0 && entity.Transform.position.y < -9.5f)
                return;

            entity.Transform.Translate(new Vector3(entity.PlayerInputComponent.horizontal, entity.PlayerInputComponent.vertical, 0) * entity.PlayerInputComponent.speed * Time.deltaTime);
        }

    }

}
