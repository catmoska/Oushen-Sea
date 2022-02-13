using UnityEngine;

public class cameraControler : MonoBehaviour
{
    public GameObject pleir;
    public float smes;
    public float smes3D;
    public bool D = true;
    private bool DS = true;

    public GameObject volna;


    void FixedUpdate()
    {
        if (D)
        {
            transform.position = new Vector3(pleir.transform.position.x / 15, pleir.transform.position.y + smes, -10);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            if (D != DS)
            {
                volna.transform.localPosition = new Vector3(3.15f, -0.460001f, 54f);
                volna.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                volna.transform.localScale = new Vector3(1.2588f, 1.2588f, 1.2588f);
                DS = D;
            }
        }
        else
        {
            transform.position = new Vector3(pleir.transform.position.x / 15, pleir.transform.position.y + smes3D, -50);
            transform.rotation = Quaternion.Euler(new Vector3(-40, 0, 0));
            if (D != DS)
            {
                volna.transform.localPosition = new Vector3(3.15f, 45.1f, 139);
                volna.transform.localRotation = Quaternion.Euler(new Vector3(32.7f, 0, 180));
                volna.transform.localScale = new Vector3(1.2588f, 1.2588f, 1.2588f);
                DS = D;
            }
        }
    }
}
