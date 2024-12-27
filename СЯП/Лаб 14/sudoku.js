class Sudoku {
    constructor() {
        this.resetBoard();
    }

    resetBoard() {
        this.board = Array.from({ length: 9 }, () => Array(9).fill(0));
    }

    generateEmptyBoard() {

        this.generateFullBoard();

        for (let i = 0; i < 81; i++) {
            if (Math.random() < 0.5) {
                const row = Math.floor(i / 9);
                const col = i % 9;
                this.board[row][col] = 0;
            }
        }
    }

    generateFullBoard() {
        this.resetBoard();
        const fillBoard = (row, col) => {
            if (row === 9) return true;
            const nextRow = col === 8 ? row + 1 : row;
            const nextCol = (col + 1) % 9;
            const numbers = Array.from({ length: 9 }, (_, i) => i + 1).sort(() => Math.random() - 0.5);

            for (let num of numbers) {
                if (this.#isValidMove(row, col, num)) {
                    this.board[row][col] = num;
                    if (fillBoard(nextRow, nextCol)) return true;
                    this.board[row][col] = 0;
                }
            }
            return false;
        };

        fillBoard(0, 0);
    }

    #isValidMove(row, col, num) {
        for (let i = 0; i < 9; i++) {
            if (this.board[row][i] === num || this.board[i][col] === num) return false;
        }
        const rowStart = Math.floor(row / 3) * 3;
        const colStart = Math.floor(col / 3) * 3;
        for (let r = rowStart; r < rowStart + 3; r++) {
            for (let c = colStart; c < colStart + 3; c++) {
                if (this.board[r][c] === num) return false;
            }
        }
        return true;
    }

    checkBoard() {
        const errors = { rows: [], columns: [], squares: [] };

        const checkRow = (row) => {
            const seen = new Set();
            for (let col = 0; col < 9; col++) {
                const value = this.board[row][col];
                if (value !== 0) {
                    if (seen.has(value)) return true;
                    seen.add(value);
                }
            }
            return false;
        };

        const checkColumn = (col) => {
            const seen = new Set();
            for (let row = 0; row < 9; row++) {
                const value = this.board[row][col];
                if (value !== 0) {
                    if (seen.has(value)) return true;
                    seen.add(value);
                }
            }
            return false;
        };

        const checkSquare = (rowStart, colStart) => {
            const seen = new Set();
            for (let row = rowStart; row < rowStart + 3; row++) {
                for (let col = colStart; col < colStart + 3; col++) {
                    const value = this.board[row][col];
                    if (value !== 0) {
                        if (seen.has(value)) return true;
                        seen.add(value);
                    }
                }
            }
            return false;
        };

        for (let i = 0; i < 9; i++) {
            if (checkRow(i)) errors.rows.push(i);
            if (checkColumn(i)) errors.columns.push(i);
        }

        for (let row = 0; row < 9; row += 3) {
            for (let col = 0; col < 9; col += 3) {
                if (checkSquare(row, col)) errors.squares.push([row / 3, col / 3]);
            }
        }
        return errors;
    }
}

function generateNewGame() {
    sudoku.generateEmptyBoard();
    generateBoard();
}

function generateSolvedBoard() {
    sudoku.generateFullBoard();
    generateBoard();
}

function generateBoard() {
    boardElement.innerHTML = '';
    sudoku.board.forEach((row, rowIndex) => {
        row.forEach((cell, colIndex) => {
            const cellElement = document.createElement('div');
            cellElement.className = 'cell';

            const input = document.createElement('input');
            input.type = 'text';
            input.maxLength = 1;
            input.value = cell !== 0 ? cell : '';
            input.disabled = cell !== 0;
            input.addEventListener('input', (e) => {
                const value = parseInt(e.target.value, 10);
                if (isNaN(value) || value < 1 || value > 9) {
                    e.target.value = '';
                } else {
                    sudoku.board[rowIndex][colIndex] = value;
                }
            });

            cellElement.appendChild(input);
            boardElement.appendChild(cellElement);
        });
    });
}

function checkErrors() {
    const errors = sudoku.checkBoard();
    const cells = document.querySelectorAll('.cell');
    cells.forEach((cell, index) => cell.classList.remove('error', 'correct'));

    if (!errors.rows.length && !errors.columns.length && !errors.squares.length) {
        cells.forEach((cell) => cell.classList.add('correct'));
        return;
    }

    errors.rows.forEach((row) => {
        for (let col = 0; col < 9; col++) {
            cells[row * 9 + col].classList.add('error');
        }
    });

    errors.columns.forEach((col) => {
        for (let row = 0; row < 9; row++) {
            cells[row * 9 + col].classList.add('error');
        }
    });

    errors.squares.forEach(([squareRow, squareCol]) => {
        for (let row = squareRow * 3; row < squareRow * 3 + 3; row++) {
            for (let col = squareCol * 3; col < squareCol * 3 + 3; col++) {
                cells[row * 9 + col].classList.add('error');
            }
        }
    });
}

const sudoku = new Sudoku();
const boardElement = document.getElementById('board');
generateNewGame();