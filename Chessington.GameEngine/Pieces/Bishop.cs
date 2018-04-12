using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board) 
        {

            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();

            for (var i = 0; i < 8; i++)
            {
                var placeICanMove = new Square(myLocation.Row + i, myLocation.Col + i);
                if (placeICanMove != myLocation && placeICanMove.Row < 8  && placeICanMove.Col < 8)
                {
                    legalMoves.Add(placeICanMove);
                }
                placeICanMove = new Square(myLocation.Row + i, myLocation.Col - i);
                if (placeICanMove != myLocation && placeICanMove.Row < 8 && placeICanMove.Col >= 0)
                {
                    legalMoves.Add(placeICanMove);
                }
                placeICanMove = new Square(myLocation.Row - i, myLocation.Col + i);
                if (placeICanMove != myLocation && placeICanMove.Row >= 0 && placeICanMove.Col < 8)
                {
                    legalMoves.Add(placeICanMove);
                }
                 placeICanMove = new Square(myLocation.Row - i, myLocation.Col - i);
                if (placeICanMove != myLocation && placeICanMove.Row >= 0 && placeICanMove.Col >= 0)
                {
                    legalMoves.Add(placeICanMove);
                }
            }


            return legalMoves;
        }
    } 
}