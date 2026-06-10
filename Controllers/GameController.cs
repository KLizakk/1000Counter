using _1000Counter.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1000Counter.Controllers;

public class GameController : Controller
{
    private static GameViewModel _game = new GameViewModel();

    public IActionResult Index()
    {
        if (_game.Players == null)
            _game.Players = new List<Player>();

        return View(_game);
    }

    [HttpPost]
    public IActionResult Setup(string[] playerNames)
    {
        _game.Players = playerNames
            .Where(n => !string.IsNullOrWhiteSpace(n))
            .Select(n => new Player { Name = n, Score = 0 })
            .ToList();

        _game.CurrentRound = 1;

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddRound(int[] points)
    {
        for (int i = 0; i < _game.Players.Count; i++)
        {
            _game.Players[i].Score += points[i];
        }

        _game.CurrentRound++;

        return RedirectToAction("Index");
    }

    public IActionResult Reset()
    {
        _game = new GameViewModel();
        return RedirectToAction("Index");
    }
}