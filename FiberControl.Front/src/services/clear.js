const form = document.getElementById('entradas')
const selectOlt = document.getElementById('select-olt')
const input = document.getElementById('input')
const output = document.getElementById('output')
const text = document.getElementById('retorno-limpeza')
const btn = document.getElementById('start')
const stop = document.getElementById('stop')
let funcao;

btn.addEventListener("click", async () => {
    olt = selectOlt.getAttribute("value");
    console.log(input.value);
    porta = input.value;
    
    
    startProcess();
})

function startProcess() {
    btn.innerText = "Terminar Limpeza";
    btn.id = "stop";
    let chave = 0

    funcao = setInterval(async () => {
        const dado = await puxarDadosOlt()
        localStorage.setItem(`dado${chave}`, dado)

        let penultimoDado = localStorage.getItem(`dado${chave - 1}`)
        let ultimoDado = dado;

        if(penultimoDado !== null && penultimoDado !== undefined && chave > 0) {
            if(penultimoDado == ultimoDado) {
                text.innerText = ""
                text.innerText = "Pedir para o técnico retirar uma porta"
            }else{
                text.innerText = ""
                text.innerText = "A ONU de Id X ficou offline após o técnico retirar a porta"
            }
        }

        chave++;

    }, 5000)
}

btn.addEventListener("click", (event) => {
    event.preventDefault();
    
    if (btn.id === "stop") {
        clearInterval(funcao);
        btn.innerText = "Começar Limpeza";
        btn.id = "start";
    } else {
        startProcess();
    }
});

async function puxarDadosOlt() {
    const response = await fetch("https://localhost:7054/olt/clear", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            olt,
            slot,
            porta
        })
    })

    if(!response.ok) {
        alert("Houve algum erro interno ao tentar realizar a limpeza")
    } 

    const data = response.json();

    return data;
}
