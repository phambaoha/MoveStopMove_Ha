using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public const string TAG_PLAYER = "Player";

    public const string TAG_BOT = "Bot";

    public const string TAG_ANIM_IDLE = "Idle";

    public const string TAG_ANIM_RUN = "Run";

    public const string TAG_ANIM_ATTACK = "Attack";

    public const string TAG_ANIM_DEAD = "Dead";

    public const string TAG_GROUND = "Ground";

    public const string TAG_OBSTACLES = "Obstacles";

    public const string TAG_ANIM_VICTORY = "Win";

    public const string TAG_ANIM_ATTTOIDLE = "AttToIdle";
}

public enum ColorType { Red,Blue,Green, None }

public enum PantType { Orion, Pokemon, RainBow, None }

public enum WeaponOnHandType { Axe, Knife, Boomerang}

public enum HatType { BunnyEar, Hat, Horn, None }
