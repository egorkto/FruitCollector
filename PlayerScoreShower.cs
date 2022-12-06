using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreShower : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text totalProfit;

    private void OnEnable()
    {
        player.ShowScore += ShowScore;
        player.ShowProfit += ShowProfit;
    }

    private void OnDisable()
    {
        player.ShowScore -= ShowScore;
        player.ShowProfit -= ShowProfit;
    }

    private void ShowScore(long score)
    {
        scoreText.text = ScoreConverter.Convert(score);
    }

    private void ShowProfit(long profit)
    {
        totalProfit.text = ScoreConverter.Convert(profit) + "/sec";
    }
}
