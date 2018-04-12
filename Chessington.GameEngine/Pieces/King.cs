using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            var placeICanMove = new Square();

            placeICanMove = Square.At(myLocation.Row - 1, myLocation.Col + 1);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row - 1, myLocation.Col - 1);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 1, myLocation.Col + 1);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 1, myLocation.Col - 1);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row, myLocation.Col - 1);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row, myLocation.Col + 1);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 1, myLocation.Col);
            CheckLegal(board, legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row - 1, myLocation.Col);
            CheckLegal(board, legalMoves, placeICanMove);

            return legalMoves;
        }

    }
}