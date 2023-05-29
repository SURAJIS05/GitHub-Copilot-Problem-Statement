// Transaction Data
let transactions = [];
let balance = 0;

// Transaction Form
const transactionForm = document.getElementById('transactionForm');
const typeInput = document.getElementById('type');
const amountInput = document.getElementById('amount');

// Transaction Table
const transactionTable = document.getElementById('transactionTable');

// Balance Display
const balanceDisplay = document.getElementById('balance');

// Edit Mode
let editMode = false;
let editIndex = null;

// Add/Edit Transaction
transactionForm.addEventListener('submit', function(e) {
  e.preventDefault();

  const type = typeInput.value;
  const amount = parseFloat(amountInput.value);

  if (isNaN(amount)) {
    alert('Please enter a valid amount.');
    return;
  }

  if (editMode) {
    transactions[editIndex].type = type;
    transactions[editIndex].amount = amount;
    editMode = false;
    editIndex = null;
  } else {
    const transaction = {
      type: type,
      amount: amount
    };

    transactions.push(transaction);
  }

  updateTransactionTable();
  updateBalance();

  // Clear input fields
  typeInput.value = 'income';
  amountInput.value = '';
});

// Delete Transaction
function deleteTransaction(index) {
  transactions.splice(index, 1);
  updateTransactionTable();
  updateBalance();
}

// Edit Transaction
function editTransaction(index) {
  editMode = true;
  editIndex = index;

  const transaction = transactions[index];
  typeInput.value = transaction.type;
  amountInput.value = transaction.amount;
}

// Update Transaction Table
function updateTransactionTable() {
  transactionTable.innerHTML = `
    <tr>
      <th>Type</th>
      <th>Amount</th>
      <th>Action</th>
    </tr>
  `;

  transactions.forEach((transaction, index) => {
    const row = document.createElement('tr');
    row.innerHTML = `
      <td>${transaction.type}</td>
      <td>${transaction.amount.toFixed(2)}</td>
      <td>
        <button onclick="editTransaction(${index})">Edit</button>
        <button onclick="deleteTransaction(${index})">Delete</button>
      </td>
    `;
    transactionTable.appendChild(row);
  });
}

// Update Balance
function updateBalance() {
  balance = transactions.reduce((total, transaction) => {
    if (transaction.type === 'income') {
      return total + transaction.amount;
    } else {
      return total - transaction.amount;
    }
  }, 0);

  balanceDisplay.textContent = `Current Balance: $${balance.toFixed(2)}`;
}
