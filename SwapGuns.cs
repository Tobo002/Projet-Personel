using UnityEngine;

public class SwapGuns : MonoBehaviour
{

    public GameObject sword;
    public GameObject gun;

    void Update()
    {
        Swap();
    }

    void Swap()
    {
        if (Input.GetButtonDown("Swap"))
        {
            bool cum = this.GetComponent<MeleeCombat>().enabled ? false : true;

            this.GetComponent<MeleeCombat>().enabled = cum;
            sword.SetActive(cum);
            this.GetComponent<GunCombat>().enabled = !cum;
            gun.SetActive(!cum);

        }
    }

}
