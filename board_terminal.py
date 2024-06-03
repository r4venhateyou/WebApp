# Tic Tac Toe Game in Python

def initialize_board():
    return [['-' for _ in range(3)] for _ in range(3)]

def display_board(board):
    for row in board:
        print(' '.join(row))

def is_valid_move(board, row, col):
    return 0 <= row < 3 and 0 <= col < 3 and board[row][col] == '-'

def make_move(board, row, col, player):
    board[row][col] = player

def check_for_win(board, player):
    for i in range(3):
        if all(board[i][j] == player for j in range(3)) or all(board[j][i] == player for j in range(3)):
            return True
    if all(board[i][i] == player for i in range(3)) or all(board[i][2-i] == player for i in range(3)):
        return True
    return False

def is_board_full(board):
    return all(cell != '-' for row in board for cell in row)

def main():
    board = initialize_board()
    current_player = 'X'
    while True:
        display_board(board)
        row, col = map(int, input(f"Player {current_player}'s turn. Enter row and column (e.g., 1 2): ").split())
        if not is_valid_move(board, row, col):
            print("Invalid move. Try again.")
            continue
        make_move(board, row, col, current_player)
        if check_for_win(board, current_player):
            display_board(board)
            print(f"Player {current_player} wins!")
            break
        if is_board_full(board):
            display_board(board)
            print("It's a draw!")
            break
        current_player = 'O' if current_player == 'X' else 'X'

if __name__ == "__main__":
    main()
