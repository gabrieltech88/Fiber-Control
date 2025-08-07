async function puxarDadosOltQuedas(nome, porta) {
    const response = await fetch("https://localhost:7155/olt/queda", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            nome,
            porta
        })
    })

    const data = await response.json();
    //console.log(data)

    return data;
}

export default puxarDadosOltQuedas