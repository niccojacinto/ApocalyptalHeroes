using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    private PlayerController playerController;

    private GameObject gui_portrait;
    private GameObject gui_mode;
    private GameObject guiText_ammo;
    private GameObject guiText_metal;
    private GameObject guiText_wood;
    private GameObject guiText_copper;

    private GameObject[] healthbar;
    private int health_index;
    public Object lives;
    public Texture2D icon_combat;
    public Texture2D icon_construct;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        gui_portrait = GameObject.Find("/GUI/gui_portrait");
        gui_mode = GameObject.Find("/GUI/gui_mode");
        guiText_ammo = GameObject.Find("/GUI/gui_ammo/guiText_ammo");
        guiText_metal = GameObject.Find("/GUI/gui_ammo/gui_metal/guiText_metal");
        guiText_wood = GameObject.Find("/GUI/gui_ammo/gui_wood/guiText_wood");
        guiText_copper = GameObject.Find("/GUI/gui_ammo/gui_copper/guiText_copper");
        InitializeHealth();
        healthbar = GameObject.FindGameObjectsWithTag("Life");
        health_index = playerController.Lives;
        Debug.Log(healthbar);
    }


    void Update()
    {
        DisplayHealth();
        DisplayMode();
        DisplayResources();

    }
    void InitializeHealth()
    {
        // Initialize the healthbar with playerController.Lives number of hearts.
         for (int i = 0; i < playerController.Lives; i++)
            { 
                Instantiate(lives, new Vector3((i - 5) * 1.2f, 5.5f, 0), Quaternion.identity);
            }
    }

    void DisplayHealth()
    {
        // Maintain (keep updating) Health.
        // Any changes in health must be handled in PlayerController before entering this function.
        while (health_index != playerController.Lives)
        {
            if (playerController.Lives < health_index)
            {
                health_index--;
                healthbar[health_index].renderer.enabled = false;
            }
            else if (playerController.Lives > health_index)
            {
                healthbar[health_index].renderer.enabled = true;
                health_index++;
            }
        }
    }

    void DisplayMode()
    {
        switch (playerController.CurrentMode)
        {
            case PlayerController.GameMode.COMBAT:
                {
                    gui_mode.guiTexture.texture = icon_combat;
                    break;
                }
            case PlayerController.GameMode.CONSTRUCT:
                {
                    gui_mode.guiTexture.texture = icon_construct;
                    break;
                }
        }
    }
    void DisplayResources()
    {
        guiText_ammo.guiText.text = playerController.Ammo.ToString();
        guiText_metal.guiText.text = playerController.Metal.ToString();
        guiText_wood.guiText.text = playerController.Wood.ToString();
        guiText_copper.guiText.text = playerController.Copper.ToString();
    }

}
