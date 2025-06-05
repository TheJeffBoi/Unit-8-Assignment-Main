using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public Animator fade;
    public GameObject fadeObj;

    public int minDamage;
    public int maxDamage;
    int playerHealth = 100;
    int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        print("Player Health =" + playerHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy Bullet")
        {
            AudioManager.PlaySound(SoundType.Damage, 0.5f);

            damage = Random.Range(minDamage, maxDamage);
            playerHealth = playerHealth - damage;

            print("Player Took Damage");
            
            healthBar.value = playerHealth;
        }
    }

    void DeathCheck()
    {
        if (playerHealth <= 0)
        {
            StartCoroutine(DoDeath());
        }
    }

    IEnumerator DoDeath()
    {
        fadeObj.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        fade.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Death");
    }
}
