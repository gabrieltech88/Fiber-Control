import puxarDadosOltQuedas from "./oltQuedas.js";

const outputClient = document.getElementById('output-client');

async function mostrarClientes(nome, porta) {
    const clientes = await puxarDadosOltQuedas(nome, porta);
    console.log(clientes)

    outputClient.innerHTML = ""
    outputClient.innerHTML = '<p id="text-client" class="text">ID | CAUSA DA QUEDA </p> <hr>'

    clientes.forEach((cliente) => {
        outputClient.innerHTML += `<p class="text-queda text">${cliente[0]} - ${cliente[1]}</p>`
    })
}

export default mostrarClientes