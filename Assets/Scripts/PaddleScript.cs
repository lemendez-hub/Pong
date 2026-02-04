using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleScript : MonoBehaviour{
    public enum ControlType{
        WS, 
        Arrows
    }

    public ControlType controls;
    public float speed = 5f;
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if(Keyboard.current == null)
        {
            return;
        }
        float movementZ = 0f;

        if(controls == ControlType.WS)
        {
            if(Keyboard.current.wKey.isPressed){
                movementZ = movementZ + 1f;
            }
            if(Keyboard.current.sKey.isPressed){
                movementZ = movementZ - 1f;
            }
        }else if(controls == ControlType.Arrows){
            if(Keyboard.current.upArrowKey.isPressed){
                movementZ = movementZ + 1f;
            }
            if(Keyboard.current.downArrowKey.isPressed){
                movementZ = movementZ - 1f;
            }
        }
        rb.linearVelocity = new Vector3(0f, 0f, movementZ * speed);
    }
}