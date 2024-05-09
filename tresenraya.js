const board = document.getElementById('board');
let currentPlayer = 'X';
let gameActive = true;
const gameState = ["", "", "", "", "", "", "", "", ""];

function handleCellClick(clickedCellEvent) {
  const clickedCell = clickedCellEvent.target;
  const clickedCellIndex = parseInt(clickedCell.getAttribute('data-index'));

  if (gameState[clickedCellIndex] !== "" || !gameActive) {
    return;
  }

  gameState[clickedCellIndex] = currentPlayer;
  clickedCell.innerHTML = currentPlayer;

  if (checkWin()) {
    alert(`¡El jugador ${currentPlayer} ha ganado!`);
    gameActive = false;
    return;
  }

  if (checkDraw()) {
    alert("¡Empate!");
    gameActive = false;
    return;
  }

  currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
}

function checkWin() {
  const winConditions = [
    [0, 1, 2], [3, 4, 5], [6, 7, 8], // Horizontal
    [0, 3, 6], [1, 4, 7], [2, 5, 8], // Vertical
    [0, 4, 8], [2, 4, 6] // Diagonal
  ];

  return winConditions.some(combination => {
    const [a, b, c] = combination;
    return gameState[a] !== "" && gameState[a] === gameState[b] && gameState[a] === gameState[c];
  });
}

function checkDraw() {
  return gameState.every(cell => cell !== "");
}

function initializeBoard() {
  for (let i = 0; i < 9; i++) {
    const cell = document.createElement('div');
    cell.classList.add('cell');
    cell.setAttribute('data-index', i);
    cell.addEventListener('click', handleCellClick);
    board.appendChild(cell);
  }
}

initializeBoard();