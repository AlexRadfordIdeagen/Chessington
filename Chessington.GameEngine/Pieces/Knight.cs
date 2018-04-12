using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            var place = new Square();

            place = Square.At(myLocation.Row - 2, myLocation.Col + 1);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row - 2, myLocation.Col - 1);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row - 1, myLocation.Col + 2);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row - 1, myLocation.Col - 2);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row + 2, myLocation.Col - 1);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row + 2, myLocation.Col + 1);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row + 1, myLocation.Col + 2);
            CheckLegal(board, legalMoves, place);

            place = Square.At(myLocation.Row + 1, myLocation.Col - 2);
            CheckLegal(board, legalMoves, place);


            legalMoves.Remove(myLocation);
            return legalMoves;
        }



    }
}