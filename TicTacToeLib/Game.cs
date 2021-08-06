using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLib
{
    public class Game
    {
        private Board _board;
        private List<Player> _players;
        private bool isPlayer1TurnStarted;
        private GameState _gameStatus;

        public Game(Board board)
        {
            _board = board;
            _players = new List<Player>();
            isPlayer1TurnStarted = true;
            _gameStatus = GameState.RUNNING;
        }

        public void AddPlayers(Player player)
        {
            _players.Add(player);
        }

        public void Play(int index)
        {
            try
            {
                Player currentPlayer = getCurrentPlayer();
                ResultAnalyser checkResult = new ResultAnalyser(_board);
                _board.SetMarkOnCell(index, currentPlayer.GetMark());
                SetGameStatus(checkResult.AnalyseResult());
                SetPlayer1Turn();
            }
            catch
            {
                throw new Exception("Cell is already marked!!!");
            }
        }

        public void SetGameStatus(GameState gameStatus)
        {
            _gameStatus = gameStatus;
        }

        public void SetPlayer1Turn()
        {
            if (isPlayer1TurnStarted)
            {
                isPlayer1TurnStarted = false;
            }
            else
            {
                isPlayer1TurnStarted = true;
            }
        }

        public Board GetBoard()
        {
            return _board;
        }

        public Player getCurrentPlayer()
        {
            if (isPlayer1TurnStarted)
            {
                return _players.ElementAt(0);
            }
            else
            {
                return _players.ElementAt(1);
            }
        }

        public GameState getGameStatus()
        {
            return _gameStatus;
        }

        public Player getNextPlayer()
        {
            if (isPlayer1TurnStarted)
            {
                return _players.ElementAt(1);
            }
            else
            {
                return _players.ElementAt(0);
            }
        }
    }
}
