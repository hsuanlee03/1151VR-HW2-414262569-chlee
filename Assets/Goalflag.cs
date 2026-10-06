using UnityEngine;

public class GoalFlag : MonoBehaviour
{
    [Header("結束音效")]
    [SerializeField] private AudioClip winSound;       // 放入你的達陣音效檔案
    
    [Header("灑花粒子系統")]
    [SerializeField] private ParticleSystem winParticles; // 放入你的灑花特效物件

    private AudioSource audioSource;
    private bool isGoalReached = false; // 防止重複觸發

    void Start()
    {
        // 遊戲開始時，自動在旗子身上加一個播放音效的元件
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // 💡 Unity 內建的 2D 觸發碰撞偵測方法
    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查撞到旗子的是不是「主角」（Tag 為 Player 的物件），且還沒通過終點
        if (other.CompareTag("Player") && !isGoalReached)
        {
            isGoalReached = true; // 鎖定終點，避免連續觸發
            
            Debug.Log("達陣成功！觸發灑花與音效！");

            // 1. 播放音效
            if (winSound != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            // 2. 播放灑花特效
            if (winParticles != null)
            {
                winParticles.Play();
            }
        }
    }
}