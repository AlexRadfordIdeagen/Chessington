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

            for (var i = 0; i < 8; i++)
            {
                var placeICanMove = new Square(i, myLocation.Col);
                if (placeICanMove != myLocation)
                {
                    legalMoves.Add(placeICanMove);
                }
                placeICanMove = new Square(myLocation.Row, i);
                if (placeICanMove != myLocation)
                {
                    legalMoves.Add(placeICanMove);
                }
            }

            return legalMoves;
        }
    }
}