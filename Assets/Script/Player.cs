using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Text text = null;
    public enum mode
    {
        NORMAL,
        POWER,
    }

    public mode _Mode = mode.NORMAL;
    public int coin = 0;
    //310개 클리어


    void Start()
    {
    }

    private void Update()
    {
        switch (_Mode)
        {
            case mode.NORMAL:
                NORMAL();
                break;
            case mode.POWER:
                NORMAL();
                PowerMode();
                break;

        }
        text.text = coin.ToString();
    }
    
    public void NORMAL()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, v);
        this.transform.position += dir *5* Time.deltaTime;
    }
    private void OnTriggerEnter(Collider _col)
    {
        if(_Mode == mode.NORMAL)
        {
            if (_col.CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(2);
            }
        }
        else if(_Mode == mode.POWER)
        {
            if (_col.CompareTag("Enemy"))
            {
                Enemy enemy = _col.GetComponent<Enemy>();
                enemy.Beck();
                Debug.Log(enemy.transform.position);
            }
        }
        
    }
    public void CoinPP()
    {
        ++coin;
    }
    
    public IEnumerator PowerMode()
    {
        _Mode = mode.POWER;
        yield return new WaitForSeconds(5f);
        _Mode = mode.NORMAL;
    }
}
