using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [Header("Input controls")]
    [SerializeField] PlayerInput input;
    [SerializeField] InputActionReference moveActionRef;
    [SerializeField] InputActionReference runActionRef;
    [SerializeField] InputActionReference jumpActionRef;

    //referencias componentes
    MOVE2D move2D;
    JUMP2D jump2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (input==null)input=FindAnyObjectByType<PlayerInput>();
        
        //formas alternativas
        //moveAction = input.action["Move"]
        //inputAction move=InputSystem.action["Move"]

        //inicilizamos refernecias
        move2D =GetComponent<MOVE2D>();
        jump2D = GetComponent<JUMP2D>();
    }

    private void OnEnable()
    {
        jumpActionRef.action.performed += jump2D.Jump;
        runActionRef.action.performed += move2D.Run;
    }

    private void OnDisable()
    {
        jumpActionRef.action.performed -= jump2D.Jump;
        runActionRef.action.performed -= move2D.Run;
    }

    // Update is called once per frame
    void Update()
    {
        move2D.Move(moveActionRef.action.ReadValue<Vector2>());
        //if (jumpActionRef.action.triggered) jump2D.Jump();
    }
}
