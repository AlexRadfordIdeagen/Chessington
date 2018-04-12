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

            if (Player == Player.Black) PawnMoveCheck(board, myLocation, legalMoves, 1);
            if (Player == Player.White) PawnMoveCheck(board, myLocation, legalMoves, -1);

            if (Player == Player.White && !hasMoved) IsSomethingInFront(board, myLocation, legalMoves, -2);
            
            if (Player == Player.Black && !hasMoved) IsSomethingInFront(board, myLocation, legalMoves, 2);
          
            return legalMoves;
        }

        private static void IsSomethingInFront(Board board, Square myLocation, List<Square> legalMoves, int movement)
        {
            var place = new Square(myLocation.Row + movement, myLocation.Col);
            var placeInFront = new Square(myLocation.Row + movement/2, myLocation.Col);
            if (place.IsSquareValid() && board.GetPiece(place) == null)
            {
                if (placeInFront.IsSquareValid() &&
                    board.GetPiece(placeInFront) == null)
                {
                    legalMoves.Add(place);

                }
            }
        }

        private void PawnMoveCheck(Board board, Square myLocation, List<Square> legalMoves, int movement)
        {
            var place = new Square(myLocation.Row + movement, myLocation.Col);
            var enemyCheckLeft = new Square(myLocation.Row + movement, myLocation.Col - 1);
            var enemyCheckRight = new Square(myLocation.Row + movement, myLocation.Col + 1);
            
            if (place.IsSquareValid() &&
            board.GetPiece(place) == null
                )
            {
                legalMoves.Add(place);
            }

            if (
                enemyCheckLeft.IsSquareValid() &&
                board.GetPiece(enemyCheckLeft) != null &&
                board.GetPiece(enemyCheckLeft).Player != Player
                )
            {
                legalMoves.Add(enemyCheckLeft);
            }

            if (
                enemyCheckRight.IsSquareValid() &&
                board.GetPiece(enemyCheckRight) != null &&
                board.GetPiece(enemyCheckRight).Player != Player
                )
            { 
                legalMoves.Add(enemyCheckRight);
            }
        }
    }
}