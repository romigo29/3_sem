class Sudoku {
    constructor() {
        this.resetBoard();
    }


    resetBoard() {
        this.board = Array.from({ length: 9 }, () => Array(9).fill(0));
    }


    #checkRow(row) {
        const seen = new Set();
        for (let col = 0; col < 9; col++) {
            const value = this.board[row][col];
            if (value !== 0) {
                if (seen.has(value)) return row + 1;
                seen.add(value);
            }
        }
        return null;
    }

    #checkColumn(col) {
        const seen = new Set();
        for (let row = 0; row < 9; row++) {
            const value = this.board[row][col];
            if (value !== 0) {
                if (seen.has(value)) return col + 1;
                seen.add(value);
            }
        }
        return null;
    }

    #checkSquare(rowStart, colStart) {
        const seen = new Set();
        for (let row = rowStart; row < rowStart + 3; row++) {
            for (let col = colStart; col < colStart + 3; col++) {
                const value = this.board[row][col];
                if (value !== 0) {
                    if (seen.has(value)) return [rowStart / 3 + 1, colStart / 3 + 1];
                    seen.add(value);
                }
            }
        }
        return null;
    }

    checkBoard() {
        let errors = { rows: [], columns: [], squares: [] };

        for (let i = 0; i < 9; i++) {
            const rowError = this.#checkRow(i);
            if (rowError) errors.rows.push(rowError);

            const colError = this.#checkColumn(i);
            if (colError) errors.columns.push(colError);
        }

        for (let row = 0; row < 9; row += 3) {
            for (let col = 0; col < 9; col += 3) {
                const squareError = this.#checkSquare(row, col);
                if (squareError) errors.squares.push(`(${squareError[0]}, ${squareError[1]})`);
            }
        }

        console.log("Ошибки:");
        if (errors.rows.length) console.log(`Строки: ${errors.rows.join(", ")}`);
        if (errors.columns.length) console.log(`Столбцы: ${errors.columns.join(", ")}`);
        if (errors.squares.length) console.log(`Квадраты: ${errors.squares.join(", ")}`);
        if (!errors.rows.length && !errors.columns.length && !errors.squares.length)
            console.log("Ошибок нет!");
    }

    generateBoard() {
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

    // Проверка возможности установить число в ячейку
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

    // Вывод игрового поля
    printBoard() {

        const separator = "+-------+-------+-------+";

        for (let row = 0; row < 9; row++) {
            let result = "|";

            for (let col = 0; col < 9; col++) {
                result += this.board[row][col];
                result += (col + 1) % 3 === 0 ? " | " : " ";
            }
            console.log(result.trim());
            if ((row + 1) % 3 === 0) console.log(separator);
        }
    }
}


// Пример использования
const sudoku = new Sudoku();
sudoku.generateBoard();
sudoku.printBoard();
sudoku.checkBoard();
sudoku.resetBoard();
sudoku.printBoard();
sudoku.generateBoard();
sudoku.printBoard();
