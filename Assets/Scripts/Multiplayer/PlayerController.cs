using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField]
    //GameObject cameraHolder;

    //[SerializeField]
    //float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;

    //float verticalLockRotation;
    //bool grounded;
    //Vector3 smoothMoveVelocity;
    //Vector3 moveAmount;


    //Rigidbody rb;

    public PhotonView PV;
    Unit g;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //throw new System.NotImplementedException();
    }

    private void Awake()
    {

        PV = GetComponent<PhotonView>();

    }
   
    private void Start()
    {
        // rb = GetComponent<Rigidbody>();

        if (!PV.IsMine && gameObject.tag == "MainCamera")
        {
            Destroy(GetComponent<Camera>().gameObject);
            //Destroy(rb);
            return;
        }


    }
    [PunRPC]
    public void SetPosition(Vector3 position)
    {
        //if (PV.IsMine)
        
        transform.position = position;
    }
    //[PunRPC]
    //public void Initialize(int owner, Building unit)
    //{
    //    //if (PV.IsMine)
    //    GetComponent<UnitManager>().SetOwnerMaterial(owner);
    //    GetComponent<UnitManager>().Initialize(unit);
    //}
    [PunRPC]
    public void SetPositionCaracter(Vector3 position)
    {
        //if (PV.IsMine)
        GetComponent<NavMeshAgent>().Warp(position);
    }

    private void Update()
    {
        if (!PV.IsMine) return;
        //Look();
        //Move();
        //Jump();

    }

    //void Look()
    //{
    //    transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

    //    verticalLockRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
    //    verticalLockRotation = Mathf.Clamp(verticalLockRotation, -90f, 90f);

    //    cameraHolder.transform.localEulerAngles = Vector3.left * verticalLockRotation;
    //}

    //void Move()
    //{
    //    Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

    //    moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    //}

    //void Jump()
    //{
    //    if (Input.GetKey(KeyCode.Space) && grounded)
    //    {
    //        rb.AddForce(transform.up * jumpForce);
    //    }
    //}

    //public void SetGroundedState(bool _grounded)
    //{
    //    grounded = _grounded;
    //}

    private void FixedUpdate()
    {
        if (!PV.IsMine) return;
        //rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }


}
