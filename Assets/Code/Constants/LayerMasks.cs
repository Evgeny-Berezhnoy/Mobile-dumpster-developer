using UnityEngine;

namespace Constants
{
    public static class LayerMasks
    {

        public static readonly LayerMask PLAYER                     = LayerMask.GetMask(LayerMask.LayerToName(Layers.PLAYER));
        public static readonly LayerMask PLAYER_PROJECTILE_TARGET   = LayerMask.GetMask(LayerMask.LayerToName(Layers.ENEMY));
        public static readonly LayerMask ENEMY_PROJECTILE_TARGET    = LayerMask.GetMask(LayerMask.LayerToName(Layers.PLAYER));
        public static readonly LayerMask GROUND                     = LayerMask.GetMask(LayerMask.LayerToName(Layers.GROUND));
        public static readonly LayerMask WALL                       = LayerMask.GetMask(LayerMask.LayerToName(Layers.WALL));
        public static readonly LayerMask OBSTACLES                  = LayerMask.GetMask(LayerMask.LayerToName(Layers.GROUND), LayerMask.LayerToName(Layers.WALL));

    }

}
