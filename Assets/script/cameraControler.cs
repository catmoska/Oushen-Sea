using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject Pleir;
    public float Smesenia;
    public float Smesenia3D;
    public bool D = true;
    private bool DS = true;

    public GameObject Volna;


    void FixedUpdate()
    {
        if (D)
        {
            transform.position = new Vector3(Pleir.transform.position.x / 15, Pleir.transform.position.y + Smesenia, -10);
            if (D != DS)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Volna.transform.localPosition = new Vector3(3.15f, -0.460001f, 54f);
                Volna.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                Volna.transform.localScale = new Vector3(1.2588f, 1.2588f, 1.2588f);
                DS = D;
            }
        }
        else
        {
            transform.position = new Vector3(Pleir.transform.position.x / 15, Pleir.transform.position.y + Smesenia3D, -50);
            if (D != DS)
            {
                transform.rotation = Quaternion.Euler(new Vector3(-40, 0, 0));
                Volna.transform.localPosition = new Vector3(3.15f, 45.1f, 139);
                Volna.transform.localRotation = Quaternion.Euler(new Vector3(32.7f, 0, 180));
                Volna.transform.localScale = new Vector3(1.2588f, 1.2588f, 1.2588f);
                DS = D;
            }
        }
    }
}
