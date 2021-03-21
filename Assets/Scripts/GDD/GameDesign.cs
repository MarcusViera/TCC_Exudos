using UnityEngine;
using System.Collections;

public class GameDesign 
{
	/// <summary>
    /// Variavies para o LevelSystem e Upgrades.
	/// </summary>
    public static int LEVEL_POINTS                                                      = 3;
    public static int CURRENT_POINTS;

    //Upgrade Armadura
    public static int ARMOR_DEXTERITY_CRYSTAL_BLUE_UNLOCK                               = 100;
    public static int ARMOR_DEXTERITY_UPGRADE_POTINS                                    = 10;

    public static int ARMOR_VITALITY_CRYSTAL_RED_UNLOCK                                 = 100;
    public static int ARMOR_VITALITY_UPGRADE_POTINS                                     = 10;

    public static int ARMOR_ENERGY_CRYSTAL_YELLOW_UNLOCK                                = 100;
    public static int ARMOR_ENERGY_UPGRADE_POTINS                                       = 10;

    public static int ARMOR_PROTECTION_CRYSTAL_GREEN_UNLOCK                             = 100;
    public static int ARMOR_PROTECTION_UPGRADE_POTINS                                   = 10;
     
    /// <summary>
    /// Variavies para o Combate
    /// </summary>
	public static int DEXTERITY_MULTIPLIER                                              = 5;
	public static int VITALITY_MULTIPLIER                                               = 5;
	public static int ENERGY_MULTIPLIER                                                 = 2;
	public static float PROTECTION_MULTIPLIER                                           = 5.0f;
    public static int PACK_REGENATION                                                   = 50;

	
	/// <summary>
	/// Personagem
	/// </summary>
	/// Varivaies Principais

    //Variavies para a Movimentação 
    public static float PLAYER_SPEED                                                    = 3.5f;

    //Vitalidade e regeneração de vida
    public static int HEALTH_REGENETATION_RELOAD                                        = 1;
    public static int HEALTH_REGENERATION                                               = 10;

    //Energia e regeneração de energia
    public static int MAX_ENERGY                                                        = 100;
    public static int ENERGY_RELOAD                                                     = 1;

    //Proteção e redeneração de Proteção
    public static int SHIELD_RELOAD                                                     = 5;



	//Variavies para a Habilidade de Arma 01 e 02
	public static float WEAPON_SKILL_RELOAD                                            = 0.3f;
    //Arma 02
    public static float WEAPON_SKILL_02_PERCENTAL_90                                   = 0.9f;
    public static float WEAPON_SKILL_02_PERCENTAL_5                                    = 0.05f;
    public static float WEAPON_SKILL_02_PERCENTAL_RELOAD                               = 3.0f;
	public static float ATTACK_01                                                      = 25.0f;

	//Variaveis para o ataque especial Explosão de Energia Arma 01
	public static float ENERGY_EXPLOSION_DAMAGE_PERCENTAL                               = 1.5f;
	public static int ENERGY_EXPLOSION_COST                                             = 30;
    public static int ENERGY_EXPLOSION_RELOAD                                           = 35;

    //Varivaies para o Ataque LançaChamas Arma 02
	public static float FLAMETHROWER_PERCENTAL                                          = 0.1f;
	public static int FLAMETHROWER_COST                                                 = 1;
	public static int FLAMETHROWER_RELOAD                                               = 1;


    //Variaveis para o ataque Campo de Força Normal.
    public static int FORCE_FIELD_SPEED                                                 = 5;
    public static int FORCE_FIELD_COST                                                  = 40;
    public static int FORCE_FIELD_COST_RELOAD                                           = 30;
    // Campo de Força com cristal amarelo
    public static int FORCE_FIELD_CRYSTAL_YELLOW_NUMBER_UNLOCK                          = 100;
    public static bool FORCE_FILED_ACTIVED_CRYSTAL_YELLOW                               = false;
    public static float FORCE_FIELD_CRYSTAL_YELLOW_PERCENTAL                            = 0.8f;
    public static int FORCE_FIELD_CRYSTAL_YELLOW_DAMAGE_RELOAD                          = 1; 
    public static int FORCE_FIELD_CRYSTAL_YELLOW_COST                                   = 40;
    public static int FORCE_FIELD_CRYSTAL_YELLOW_RELOAD                                 = 30;
    //Campo de Força com cristal vermelho
    public static int FORCE_FIELD_CRYSTAL_RED_NUMBER_UNLOCK                             = 100;
    public static bool FORCE_FILED_ACTIVED_CRYSTAL_RED                                  = false;
    public static float FORCE_FIELD_CRYSTAL_RED_PERCENTAL_HEALTH                        = 0.05f;
    public static float FORCE_FIELD_CRYSTAL_RED_PERCENTAL_ENERGY                        = 0.1f;
    public static int FORCE_FIELD_CRYSTAL_RED_RELOAD_HEALTH                             = 1;
    public static int FORCE_FIELD_CRYSTAL_RED_COST                                      = 50;
    public static float FORCE_FIELD_CRYSTAL_RED_RELOAD                                  = 40f;


    //Variavies para o atque especial Sentinela
    public static float SENTINEL_PERCENTAL                                              = 0.75f;
    public static int SENTINEL_COST                                                     = 50;
    public static int SENTINEL_RELOAD                                                   = 85;
    //Sentinela com cristal azul
    public static int SENTINEL_CRYSTAL_BLUE_NUMBER_UNLOCK                               = 100;
    public static bool SENTINEL_ACTIVED_CRYSTAL_BLUE                                    = false;
    public static float SENTINEL_CRYSTAL_BLUE_PERCENTAL                                 = 0.45f;
    public static float SENTINEL_CRYSTAL_BLUE_VELOCITY_PERCENTAL                        = 0.2f;
    public static float SENTINEL_CRYSTAL_BLUE_VELOCITY_TIME                             = 5.0f;
    public static float SENTINEL_CRYSTAL_BLUE_COST                                      = 50;
    public static float SENTINEL_CRYSTAL_BLUE_RELOAD                                    = 85;
    //Sentinela com cristal verde
    public static int SENTINEL_CRYSTAL_GREEN_NUMBER_UNLOCK                              = 100;
    public static bool SENTINEL_ACTIVED_CRYSTAL_GREEN                                   = false;
    public static float SENTINEL_CRYSTAL_GREEN_PERCENTAL                                = 0.65f;
    public static int SENTINEL_CRYSTAL_GREEN_COST                                       = 50;
    public static int SENTINEL_CRYSTAL_GREEN_RELOAD                                     = 85;



	/// <summary>
	/// Inimigos
	/// </summary>
	public static float MAX_DEFENSE_INIMIGO                                             = 100.0f;
	public static float ENEMY_ATTACK_SPEED                                              = 1.0f;
    public static float ENEMY_SPEED                                                     = 3.0f;
    public static float ENEMY_PERCENTAL_EVOLUTION                                       = 0.06f;
    public static float ENEMY_PERCENTAL_EVOLUTION_EXP                                   = 0.09f;

    //Ataque Especial
    public static float ENEMY_ATTACK_ESPECIAL                                           = 1.2f;
    public static int ENEMY_ATTACK_ESPECIAL_COST                                        = 75;
    public static int ENEMY_ATTACK_ESPECIAL_RELOAD                                      = 60;
}
