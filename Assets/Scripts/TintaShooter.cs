using UnityEngine;

public class TintaShooter : MonoBehaviour
{
    public GameObject tintaPrefab; // Prefab da esfera de tinta
    public Transform spawnPoint; // Local de onde a tinta será disparada
    public float shootForce = 20f; // Força do disparo
    public Material tintaMaterial; // Material que define a cor da tinta

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clique do mouse ou botão equivalente no controle
        {
            ShootTinta();
        }
    }

    void ShootTinta()
    {
        // Criando a esfera de tinta
        GameObject tinta = Instantiate(tintaPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = tinta.GetComponent<Rigidbody>();

        // Aplicando força para o disparo
        rb.AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);

        // Passando a referência do material da tinta para a esfera
        Tinta tintaScript = tinta.GetComponent<Tinta>();
        if (tintaScript != null)
        {
            tintaScript.SetDecalMaterial(tintaMaterial);
        }
    }
}
