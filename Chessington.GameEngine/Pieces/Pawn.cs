using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved;
        public Pawn(Player player)
            : base(player)
        {
            hasMoved = false;
        }


        public override void MoveTo(Board board, Square newSquare)
        {
            hasMoved = true;
            base.MoveTo(board, newSquare);
        }




        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var myLocation = board.FindPiece(this);
            var legalMoves = new List<Square>();
            if (Player == Player.Black && !hasMoved)
                legalMoves.Add(new Square(myLocation.Row + 2, myLocation.Col));
            if (Player == Player.Black)
            {
                legalMoves.Add(new Square(myLocation.Row + 1, myLocation.Col));
            }

            if (Player == Player.White && !hasMoved)
                legalMoves.Add(new Square(myLocation.Row - 2, myLocation.Col));
            if (Player == Player.White)
            {
                legalMoves.Add(new Square(myLocation.Row - 1, myLocation.Col));
            }


            return legalMoves;

        }
    }
}