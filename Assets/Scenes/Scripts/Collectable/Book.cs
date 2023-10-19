using UnityEngine;

public class Book : Collectable
{
    [Header("Level Info")]
    [SerializeField] private int levelIncreaseAmount = 6;

    protected override void Collect()
    {
        base.Collect();

        // Oyuncu seviyesini artır ve ekrana yazdır
        player.level += levelIncreaseAmount;
        player.levelText.text = "Lv. " + player.level.ToString();
    }
}
