import puxarDadosOlt from "./oltRequest.js"

const text = document.getElementById('text')
let chave = 0

async function iniciarLimpeza(olt, porta, encerrar) {

    let dado = await puxarDadosOlt(olt, porta) //Faz a requisição e recebe um array com strings dos clientes offline
    localStorage.setItem(`dado${chave}`, JSON.stringify(dado)) //Transforma o array em string e guarda no localstorage


    if (chave > 0) { //Se a chave for maior que 0 quer dizer que existem dois registros na local storage
        const penultimoDadoRaw = localStorage.getItem(`dado${chave - 1}`); //Pegamos o penultimo item
        const ultimoDadoRaw = localStorage.getItem(`dado${chave}`); //Pegamos o ultimo item

        if (penultimoDadoRaw && ultimoDadoRaw) { //Se o ultimo e penultimo existirem, entra no if
            const ultimoDado = JSON.parse(ultimoDadoRaw); //converte ultimo item para objeto JS
            const penultimoDado = JSON.parse(penultimoDadoRaw); //converte penultimo item para objeto JS

            let clienteOff = ultimoDado.filter(x => !penultimoDado.includes(x)); //compara os dois arrays e verifica qual elemento é incomum

            if (clienteOff.length > 0) {
                const propriedades = clienteOff[0].split(" ").filter(item => item.trim() !== '');
    
                const ppoe = propriedades[5];
    
                text.textContent = `A ONU de Id ${propriedades[0]} ficou offline após o técnico retirar a porta
                PPOE: ${ppoe}
                Peça para o técnico conectar o cliente de volta`;

                while(true) {
                    const func = onuRequest(ppoe)

                    if(func === true) {
                        text.textContent = "Cliente online"
                        break;
                    }
                }

                encerrar();
    
            } else {
                text.textContent = "Pedir para o técnico retirar uma porta";
            }
        }

    }

    chave++;
}

export default iniciarLimpeza;