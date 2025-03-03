using UnityEngine;

public class Tinta : MonoBehaviour
{
    public GameObject tintaDecalPrefab; // Prefab do decal de tinta
    private Material tintaMaterial; // Material da tinta para definir cor do decal

    public void SetDecalMaterial(Material material)
    {
        tintaMaterial = material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0]; // Ponto de colisão
        Vector3 hitPosition = contact.point; // Posição exata do impacto
        Vector3 hitNormal = contact.normal; // Direção da superfície atingida

        // Criar rotação alinhada à superfície
        Quaternion hitRotation = Quaternion.FromToRotation(Vector3.up, hitNormal);

        // Instancia um decal no local do impacto
        GameObject tintaDecal = Instantiate(tintaDecalPrefab, hitPosition + hitNormal * 0.01f, hitRotation);

        // Definir o material da tinta no decal
        Renderer decalRenderer = tintaDecal.GetComponent<Renderer>();
        if (decalRenderer != null && tintaMaterial != null)
        {
            decalRenderer.material = tintaMaterial;
        }

        // Adiciona uma pequena variação aleatória no tamanho/rotação para mais naturalidade
        float randomScale = Random.Range(0.5f, 1.5f);
        tintaDecal.transform.localScale = new Vector3(randomScale, randomScale, 1f);

        // Destruir a esfera de tinta após o impacto
        Destroy(gameObject);
    }
}
