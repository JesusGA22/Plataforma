using UnityEngine;

[System.Serializable]
public class Stats
{
    [Header("Character data")]
    public string characterName;

    [Header("Move parameters")]
    public float moveSpeed = 5f;
    public float acceleration = 20f;
    public float deceleration = 40f;

    [Range(1f, 5f)] public float runModifique = 1.5f;

    [Header("Jump parameters")]
    public float jumpForce = 10f;
    public float fuerzaCaida = 1.025f;
    public float velocidadMax = 2f;
    [Range(0f, 1f)] public float airMomentum = 0.8f;
    public float saltosExtra = 1f;

    [Header("Parametros de Subida")]
    public float velocidadSubida = 5f;

}
