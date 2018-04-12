using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
        public void CheckLegal(Board board, List<Square> legalMoves, Square place)
        {
            if
                (place.IsSquareValid() && board.GetPiece(place) == null)
            {
                legalMoves.Add(place);
            }
            else if (place.IsSquareValid() && board.GetPiece(place).Player != Player)
            {
                legalMoves.Add(place);
            }
        }
    }
}