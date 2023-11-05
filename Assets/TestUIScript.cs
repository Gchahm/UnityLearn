using UnityEngine;

public class TestUIScript : MonoBehaviour
{
    public GameObject player;

    public void AddPlayerSpeed(float percentage)
    {
        player.GetComponent<PlayerScript>().SpeedModifier += percentage;
    }

    public void AddWeaponSpeed(float percentage)
    {
        player.GetComponent<PlayerScript>().Weapons
            .ForEach(weapon => weapon.GetComponent<WeaponScript>().SpeedModifer += percentage);
    }
}