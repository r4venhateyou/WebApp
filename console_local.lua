local board = {{'-', '-', '-'}, {'-', '-', '-'}, {'-', '-', '-'}}
local currentPlayer = 'X'

-- Инициализация поля
local function initializeBoard()
    for i = 1, 3 do
        for j = 1, 3 do
            board[i][j] = '-'
        end
    end
end

-- Отображение поля
local function displayBoard()
    for i = 1, 3 do
        local row = ""
        for j = 1, 3 do
            row = row .. board[i][j] .. " "
        end
        print(row)
    end
end

-- Сделать ход
local function makeMove(row, col)
    board[row][col] = currentPlayer
end

-- Проверка на победу
local function checkForWin()
    for i = 1, 3 do
        if board[i][1] == currentPlayer and board[i][2] == currentPlayer and board[i][3] == currentPlayer then
            return true -- Горизонтальная победа
        end
        if board[1][i] == currentPlayer and board[2][i] == currentPlayer and board[3][i] == currentPlayer then
            return true -- Вертикальная победа
        end
    end
    if board[1][1] == currentPlayer and board[2][2] == currentPlayer and board[3][3] == currentPlayer then
        return true -- Диагональная победа
    end
    if board[1][3] == currentPlayer and board[2][2] == currentPlayer and board[3][1] == currentPlayer then
        return true -- Диагональная победа
    end
    return false
end

-- Проверка на ничью
local function isBoardFull()
    for i = 1, 3 do
        for j = 1, 3 do
            if board[i][j] == '-' then
                return false
            end
        end
    end
    return true
end

-- Основной игровой цикл
local function main()
    initializeBoard()
    local gameOver = false
    while not gameOver do
        displayBoard()
        print(string.format("Ходит игрок %s. Введите строку и столбец для вашего хода (например, 1 2): ", currentPlayer))
        local input = io.read()
        local row, col = input:match("(%d+) (%d+)")
        row, col =
