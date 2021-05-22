using UnityEngine;

public class Confetti : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] GameObject ConfettiPrefab;

    public void PlayConfettis()
    {
        foreach (Transform t in Positions)
        {
            GameObject confetti = Instantiate(ConfettiPrefab, t.position, t.rotation);
            Destroy(confetti, 5.0f);
        }
    }
}
