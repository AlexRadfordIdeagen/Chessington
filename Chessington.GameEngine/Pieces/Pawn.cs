using System.Collections.Generic;

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

            if (Player == Player.Black) PawnMoveCheck(board, myLocation, legalMoves, +1);
            if (Player == Player.White) PawnMoveCheck(board, myLocation, legalMoves, -1);

            if (Player == Player.White && !hasMoved)
            {
                if (DoubleMovement(board, myLocation, legalMoves, -2))
                {
                    PawnMoveCheck(board, myLocation, legalMoves, -2);
                }
            }

            if (Player == Player.Black && !hasMoved)
            {
                if (DoubleMovement(board, myLocation, legalMoves, +2))
                {
                    PawnMoveCheck(board, myLocation, legalMoves, +2);
                }
            }

            return legalMoves;
        }

        private static bool DoubleMovement(Board board, Square myLocation, List<Square> legalMoves, int movement)
        {
            var placeICanMove = new Square(myLocation.Row + movement / 2, myLocation.Col);
            return
                placeICanMove.IsSquareValid() &&
                board.GetPiece(placeICanMove) == null
                    ;
        }

        private static void PawnMoveCheck(Board board, Square myLocation, List<Square> legalMoves, int movement)
        {
            var placeICanMove = new Square(myLocation.Row + movement, myLocation.Col);
            if (placeICanMove.IsSquareValid() &&
            board.GetPiece(placeICanMove) == null
                )
            {
                legalMoves.Add(placeICanMove);
            }
        }
    }
}