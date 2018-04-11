using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            CheckLegalMoves(myLocation, legalMoves);

            return legalMoves;

        }

        private void CheckLegalMoves(Square myLocation, List<Square> legalMoves)
        {
            if (Player == Player.Black)
                legalMoves.Add(new Square(myLocation.Row + 1, myLocation.Col));
            else if (Player == Player.White)
            {
                legalMoves.Add(new Square(myLocation.Row - 1, myLocation.Col));
            }
        }
    }
}