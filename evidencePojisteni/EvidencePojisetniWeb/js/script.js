// Definice třídy pojištěného
class Insured {
  constructor(firstName, lastName, age, phoneNumber) {
    this.firstName = firstName; // Uložení jména do vlastnosti firstName
    this.lastName = lastName; // Uložení příjmení do vlastnosti lastName
    this.age = age; // Uložení věku do vlastnosti age
    this.phoneNumber = phoneNumber; // Uložení telefonního čísla do vlastnosti phoneNumber
  }

  toString() {
    return `${this.firstName} ${this.lastName} (${this.age} let, tel: ${this.phoneNumber})`; // Vrátí formátovaný řetězec s údaji o pojištěnci
  }
}

const insureds = []; // Pole pro uchování pojištěnců

// Funkce pro přidání nového pojištěného z formuláře
function addInsured(event) {
  event.preventDefault(); // Zamezení výchozímu chování formuláře

  // Získání hodnot z vstupních polí formuláře
  const firstName = document.getElementById("firstName").value;
  const lastName = document.getElementById("lastName").value;
  const age = parseInt(document.getElementById("age").value); // Převedení věku na číslo
  const phoneNumber = document.getElementById("phoneNumber").value;

  const insured = new Insured(firstName, lastName, age, phoneNumber); // Vytvoření instance pojištěného
  insureds.push(insured); // Přidání pojištěného do seznamu

  displayInsureds(); // Zobrazení seznamu pojištěných v tabulce

  // Vyprázdnění vstupních polí formuláře po přidání pojištěnce
  document.getElementById("firstName").value = "";
  document.getElementById("lastName").value = "";
  document.getElementById("age").value = "";
  document.getElementById("phoneNumber").value = "";
}

// Funkce pro zobrazení seznamu pojištěných v tabulce
function displayInsureds() {
  const insuredTableBody = document.querySelector("#insuredTable tbody");
  insuredTableBody.innerHTML = ""; // Vyprázdnění tabulky před naplněním

  insureds.forEach((insured) => {
    const row = document.createElement("tr"); // Vytvoření řádku tabulky

    const nameCell = document.createElement("td");
    nameCell.textContent = insured.firstName + " " + insured.lastName; // Nastavení jména a příjmení do jedné buňky tabulky

    const ageCell = document.createElement("td");
    ageCell.textContent = insured.age; // Nastavení věku do buňky tabulky

    const phoneNumberCell = document.createElement("td");
    phoneNumberCell.textContent = insured.phoneNumber; // Nastavení telefonního čísla do buňky tabulky

    row.appendChild(nameCell); // Přidání buňky s jménem a příjmením do řádku
    row.appendChild(phoneNumberCell); // Přidání buňky s telefonním číslem do řádku
    row.appendChild(ageCell); // Přidání buňky s věkem do řádku


    insuredTableBody.appendChild(row); // Přidání řádku do tabulky
  });
}

// Event Listener pro odeslání formuláře
const newInsuredForm = document.getElementById("newInsuredForm");
newInsuredForm.addEventListener("submit", addInsured);

displayInsureds(); // Zobrazení pojištěných při načtení stránky
