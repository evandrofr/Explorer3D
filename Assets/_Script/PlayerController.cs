using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    float _baseSpeed = 10.0f;
    float _gravidade = 9.8f;
    float y;

    public bool pegou, inPuzzle, segurando;

    //Referência usada para a câmera filha do jogador
    GameObject playerCamera, puzzle;
    //Utilizada para poder travar a rotação no angulo que quisermos.
    float cameraRotation;

    CharacterController characterController;

    public GameObject textPensa;

    void Start(){
        textPensa.GetComponent<ScriptText>().UpdateText(4, "Where am I! I need to get out of here");
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        y = 0;
        segurando = false;
        pegou = false;
    }

    void Update(){
        if (!PauseScript.gameIsPaused){
            if (!inPuzzle){
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                
                //Tratando movimentação do mouse
                float mouse_dX = Input.GetAxis("Mouse X");
                float mouse_dY = Input.GetAxis("Mouse Y");

                //Tratando a rotação da câmera
                cameraRotation -= mouse_dY;
                Mathf.Clamp(cameraRotation, -90.0f, 90.0f);

                //Verificando se é preciso aplicar a gravidade
                if (characterController.isGrounded && y < 0){
                    y = -2f;
                }

                if (Input.GetButtonDown("Jump") && characterController.isGrounded){
                    y = 3f;
                }
                Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;

                y -= _gravidade * Time.deltaTime;

                characterController.Move(direction * _baseSpeed * Time.deltaTime);
                transform.Rotate(Vector3.up, mouse_dX);

                playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
            }
        }
    }

    
    void LateUpdate(){
        if (!PauseScript.gameIsPaused){
            RaycastHit hit;
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward*10.0f, Color.magenta);
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 100.0f)){
                Debug.Log(hit.collider.name);
                if(hit.collider.tag == "Interagivel" && Input.GetMouseButtonDown(0) && !segurando && !inPuzzle){
                    hit.collider.transform.parent = this.transform;
                    hit.collider.transform.position = new Vector3 (hit.collider.transform.position.x, 2.3f, hit.collider.transform.position.z);
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    segurando = true;
                    pegou = true;
                }
                else if(hit.collider.tag == "Puzzle" && Input.GetMouseButtonDown(0) && !segurando){
                    inPuzzle = true;
                    puzzle = hit.collider.gameObject;
                    Cursor.lockState = CursorLockMode.None;
                    puzzle.GetComponent<PuzzleScript>().puzzleImage.SetActive(true);
                }
                else if(hit.collider.tag == "Abrivel" && Input.GetMouseButtonDown(0) && !segurando){
                    textPensa.GetComponent<ScriptText>().UpdateText(2, "Locked...");
                }
                else if(hit.collider.tag == "Aberto" && Input.GetMouseButtonDown(0) && !segurando){
                    textPensa.GetComponent<ScriptText>().UpdateText(2, "I need to look for more clues...");
                }
            }
            if(Input.GetMouseButtonDown(0) && segurando && !pegou && !inPuzzle){
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    if (child.tag == "Interagivel")
                    {
                        child.GetComponent<Rigidbody>().useGravity = true;
                        child.transform.parent = null;
                        segurando = false;
                    }
                }
            }
            pegou = false;
        }
    }

    public void ClosePuzzle(){
        puzzle.GetComponent<PuzzleScript>().puzzleImage.SetActive(false);
        inPuzzle = false;
        puzzle = null;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

