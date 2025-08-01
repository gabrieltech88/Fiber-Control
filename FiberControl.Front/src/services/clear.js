import iniciarLimpeza from "./iniciarLimpeza.js"

const form = document.getElementById('entradas')
const selectOlt = document.getElementById('select-olt')
const input = document.getElementById('input')
const output = document.getElementById('output')
const text = document.getElementById('text')
const btn = document.getElementById('btn')
let funcao;
let intervalId = null;


btn.addEventListener("click", async () => {
    const olt = selectOlt.value;
    //console.log(olt)
    //console.log(input.value);
    const porta = input.value;

    if (intervalId === null) {
        text.textContent = "Resultado..."
        intervalId = setInterval(() => iniciarLimpeza(olt, porta, () => {
            clearInterval(intervalId);
            intervalId = null
            localStorage.clear()
            btn.textContent = "Iniciar Limpeza"
        }), 5000);
        btn.textContent = "Terminar Limpeza"
    } else {
        clearInterval(intervalId);
        intervalId = null
        localStorage.clear()
        btn.textContent = "Iniciar Limpeza"
        text.textContent = "Resultado..."
    }
})



