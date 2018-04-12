using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            for (var i = 1; i < 8; i++)
            {
                var placeICanMove = Square.At(myLocation.Row + i, myLocation.Col);
                if (
                    placeICanMove.IsSquareValid() &&
                    board.GetPiece(placeICanMove) == null
                    )
                {
                    legalMoves.Add(placeICanMove);
                }
                else break;
            }

            for (var i = 1; i < 8; i++)
            {
                var placeICanMove = Square.At(myLocation.Row, myLocation.Col + i);
                if (
                    placeICanMove.IsSquareValid() &&
                    board.GetPiece(placeICanMove) == null
                    )
                {
                    legalMoves.Add(placeICanMove);
                }
                else break;
            }

            for (var i = 1; i < 8; i++)
            {
                var placeICanMove = Square.At(myLocation.Row - i, myLocation.Col);
                if (
                    placeICanMove.IsSquareValid() &&
                    board.GetPiece(placeICanMove) == null
                    )
                {
                    legalMoves.Add(placeICanMove);
                }
                else break;
            }
            for (var i = 1; i < 8; i++)
            {
                var placeICanMove = Square.At(myLocation.Row, myLocation.Col - i);
                if (
                    placeICanMove.IsSquareValid() &&
                    board.GetPiece(placeICanMove) == null
                    )
                {
                    legalMoves.Add(placeICanMove);
                }
                else break;
            }

            legalMoves.Remove(myLocation);
            return legalMoves;
        }
    }
}