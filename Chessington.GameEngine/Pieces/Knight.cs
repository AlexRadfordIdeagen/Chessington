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
            var placeICanMove = new Square();

            placeICanMove = Square.At(myLocation.Row - 2, myLocation.Col + 1);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row - 2, myLocation.Col - 1);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row - 1, myLocation.Col + 2);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row - 1, myLocation.Col - 2);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 2, myLocation.Col - 1);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 2, myLocation.Col + 1);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 1, myLocation.Col + 2);
            LegalCheck(legalMoves, placeICanMove);

            placeICanMove = Square.At(myLocation.Row + 1, myLocation.Col - 2);
            LegalCheck(legalMoves, placeICanMove);


            legalMoves.Remove(myLocation);
            return legalMoves;
        }

        private static void LegalCheck(List<Square> legalMoves, Square placeICanMove)
        {
            if (placeICanMove.IsSquareValid())
            {
                legalMoves.Add(placeICanMove);
            }
        }
    }
}