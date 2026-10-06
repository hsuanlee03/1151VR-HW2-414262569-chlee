using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Myscript : MonoBehaviour
{

    // ====== ⬅️ 左鍵的兩張圖片 ======
    [SerializeField] private Sprite leftSprite1; 
    [SerializeField] private Sprite leftSprite2; 
    private bool isLeftAltered = false;          

    // ====== ➡️ 右鍵的兩張圖片 ======
    [SerializeField] private Sprite rightSprite1; 
    [SerializeField] private Sprite rightSprite2; 
    private bool isRightAltered = false;         

    // ====== ⬆️⬇️ 上下鍵的圖片 ======
    [SerializeField] private Sprite upSprite;    // 向上跳時的圖（會位移）
    [SerializeField] private Sprite downSprite;  // 按下鍵時的圖（純原地換圖）

    private SpriteRenderer spriteRenderer;
    private bool isJumping = false;              // 記錄目前是否處於動作鎖定中
    private string lastDirection = "right";      // 記錄最後的面朝方向

    void Start()
    {
        Application.targetFrameRate = 60;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 如果鍵盤沒接好，或是角色正在執行跳躍/下蹲動作中，就暫時不接收新按鍵
        if (Keyboard.current == null || isJumping) return; 

        // ⬅️ 按下左方向鍵
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            lastDirection = "left"; 
            isLeftAltered = !isLeftAltered;
            if (isLeftAltered) spriteRenderer.sprite = leftSprite2;
            else spriteRenderer.sprite = leftSprite1;
            transform.Translate(-3, 0, 0);
        }

        // ➡️ 按下右方向鍵
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            lastDirection = "right"; 
            isRightAltered = !isRightAltered;
            if (isRightAltered) spriteRenderer.sprite = rightSprite2;
            else spriteRenderer.sprite = rightSprite1;
            transform.Translate(3, 0, 0);
        }

        // ⬆️ 按下上方向鍵（上跳後自動回到地面與恢復原圖）——【已修正參數錯誤】
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            StartCoroutine(JumpRoutine(new Vector3(0, 1, 0), upSprite));
        }

        // ⬇️ 當按下下方向鍵時（純原地換圖，按完馬上恢復）
        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            StartCoroutine(DownRoutine(downSprite));
        }
    }

    // 💡 上方向鍵專用：跳躍與自動落地恢復
    private IEnumerator JumpRoutine(Vector3 moveOffset, Sprite jumpSprite)
    {
        isJumping = true; 
        spriteRenderer.sprite = jumpSprite;
        transform.Translate(moveOffset);

        yield return new WaitForSeconds(0.25f); // 在空中停留 0.25 秒

        transform.Translate(-moveOffset); // 自動落回原位
        ResetToGroundSprite();             // 恢復地面的圖
        isJumping = false; 
    }

    // 💡 下方向鍵專用：原地換圖與自動恢復
    private IEnumerator DownRoutine(Sprite downSprite)
    {
        isJumping = true; 
        spriteRenderer.sprite = downSprite; // 原地換圖

        yield return new WaitForSeconds(0.15f); // 圖片停留 0.15 秒後自動恢復

        ResetToGroundSprite(); // 恢復地面的圖
        isJumping = false; 
    }

    // 💡 公用方法：自動判斷並將圖片恢復成按鍵前的平地狀態
    private void ResetToGroundSprite()
    {
        if (lastDirection == "left")
        {
            if (isLeftAltered) spriteRenderer.sprite = leftSprite2;
            else spriteRenderer.sprite = leftSprite1;
        }
        else if (lastDirection == "right")
        {
            if (isRightAltered) spriteRenderer.sprite = rightSprite2;
            else spriteRenderer.sprite = rightSprite1;
        }
    }
}
