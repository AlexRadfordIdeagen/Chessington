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



            if (Player == Player.Black)
            {
                pawnMoveCheck(board, myLocation, legalMoves, +1);
            }
            if (Player == Player.White)
            {
                pawnMoveCheck(board, myLocation, legalMoves, -1);
            }

            if (Player == Player.White && !hasMoved)
            {
                if (board.GetPiece(new Square(myLocation.Row - 1, myLocation.Col)) == null)
                {
                    pawnMoveCheck(board, myLocation, legalMoves, -2);
                }
            }
            if (Player == Player.Black && !hasMoved)
            {
                if (board.GetPiece(new Square(myLocation.Row + 1, myLocation.Col)) == null)
                {
                    pawnMoveCheck(board, myLocation, legalMoves, +2);
                }
            }

            return legalMoves;
        }

        private static void pawnMoveCheck(Board board, Square myLocation, List<Square> legalMoves, int movement)
        {
            if (board.GetPiece(new Square(myLocation.Row + movement, myLocation.Col)) == null)
            {
                legalMoves.Add(new Square(myLocation.Row + movement, myLocation.Col));
            }
        }

    }
}