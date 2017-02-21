using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {

            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            for (var i = 1; i < 8; i++)
            {
                var place = new Square(myLocation.Row + i, myLocation.Col + i);
                if
                    (place.IsSquareValid() && board.GetPiece(place) == null)
                {
                    legalMoves.Add(place);
                }

                else if (place.IsSquareValid() && board.GetPiece(place).Player != Player)
                {
                    legalMoves.Add(place);
                    break;
                }
                else break;
            }

            for (var i = 1; i < 8; i++)
            {
                var place = new Square(myLocation.Row + i, myLocation.Col - i);
                if
                    (place.IsSquareValid() && board.GetPiece(place) == null)
                {
                    legalMoves.Add(place);
                }

                else if (place.IsSquareValid() && board.GetPiece(place).Player != Player)
                {
                    legalMoves.Add(place);
                    break;
                }
                else break;
            }

            for (var i = 1; i < 8; i++)
            {
                var place = new Square(myLocation.Row - i, myLocation.Col + i);
                if
                    (place.IsSquareValid() && board.GetPiece(place) == null)
                {
                    legalMoves.Add(place);
                }

                else if (place.IsSquareValid() && board.GetPiece(place).Player != Player)
                {
                    legalMoves.Add(place);
                    break;
                }
                else break;
            }

            for (var i = 1; i < 8; i++)
            {
                var place = new Square(myLocation.Row - i, myLocation.Col - i);
                if
                    (place.IsSquareValid() && board.GetPiece(place) == null)
                {
                    legalMoves.Add(place);
                }

                else if (place.IsSquareValid() && board.GetPiece(place).Player != Player)
                {
                    legalMoves.Add(place);
                    break;
                }
                else break;



            }

            return legalMoves;
        }
    }
}