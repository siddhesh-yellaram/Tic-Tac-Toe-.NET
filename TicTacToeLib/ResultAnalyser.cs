using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLib
{
    public class ResultAnalyser
    {
		private Board _board;
		private int _size;

		public ResultAnalyser(Board board)
		{
			_board = board;
			_size = board.GetSize();
		}

		private GameState checkPlayerRow()
		{
			int playerMarkO;
			int row = 0;

			while (row < _size)
			{
				playerMarkO = 0;

				for (int i = 0; i < _size; i++)
				{
					if (_board.GetCells().ElementAt(_size * row + i).GetMark().Equals(Mark.O))
					{
						playerMarkO++;
					}
					else if (_board.GetCells().ElementAt(_size * row + i).GetMark().Equals(Mark.X))
					{
						playerMarkO--;
					}
				}

				row++;
				if (Math.Abs(playerMarkO) == _size)
				{
					return GameState.FINISHED;
				}
			}

			return GameState.RUNNING;
		}

		private GameState checkPlayerColumn()
		{
			int playerMarkO;
			int column = 0;

			while (column < _size)
			{
				playerMarkO = 0;

				for (int i = 0; i < _size; i++)
				{
					if (_board.GetCells().ElementAt(i * _size + column).GetMark().Equals(Mark.O))
					{
						playerMarkO++;
					}
					else if (_board.GetCells().ElementAt(i * _size + column).GetMark().Equals(Mark.X))
					{
						playerMarkO--;
					}
				}

				column++;

				if (Math.Abs(playerMarkO) == _size)
				{
					return GameState.FINISHED;
				}
			}

			return GameState.RUNNING;
		}

		private GameState checkPlayerLeftDiagonal()
		{
			int playerMarkO = 0;

			for (int i = 0; i < _size; i++)
			{
				if (_board.GetCells().ElementAt((i * (_size + 1))).GetMark().Equals(Mark.O))
				{
					playerMarkO++;
				}
				else if (_board.GetCells().ElementAt((i * (_size + 1))).GetMark().Equals(Mark.X))
				{
					playerMarkO--;
				}
			}

			if (Math.Abs(playerMarkO) == _size)
			{
				return GameState.FINISHED;
			}

			return GameState.RUNNING;

		}

		private GameState checkPlayerRightDiagonal()
		{
			int playerMarkO = 0;

			for (int i = 0; i < _size; i++)
			{
				if (_board.GetCells().ElementAt(((i + 1) * (_size - 1))).GetMark().Equals(Mark.O))
				{
					playerMarkO++;
				}
				else if (_board.GetCells().ElementAt(((i + 1) * (_size - 1))).GetMark().Equals(Mark.X))
				{
					playerMarkO--;
				}
			}

			if (Math.Abs(playerMarkO) == _size)
			{
				return GameState.FINISHED;
			}

			return GameState.RUNNING;

		}

		private GameState checkGameIsDraw()
		{

			if (_board.IsBoardFullyMarked())
			{
				return GameState.DRAW;
			}

			return GameState.RUNNING;

		}

		public GameState AnalyseResult()
		{

			if (this.checkPlayerRow().Equals(GameState.FINISHED))
			{
				return this.checkPlayerRow();
			}

			if (this.checkPlayerColumn().Equals(GameState.FINISHED))
			{
				return this.checkPlayerColumn();
			}

			if (this.checkPlayerLeftDiagonal().Equals(GameState.FINISHED))
			{
				return this.checkPlayerLeftDiagonal();
			}

			if (this.checkPlayerRightDiagonal().Equals(GameState.FINISHED))
			{
				return this.checkPlayerRightDiagonal();
			}

			if (this.checkGameIsDraw().Equals(GameState.DRAW))
			{
				return this.checkGameIsDraw();
			}

			return GameState.RUNNING;
		}
	}
}
