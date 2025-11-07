async function puxarDadosOlt(nome, porta) {
    const response = await fetch("https://localhost:7155/api/olt/clear", {
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



export default puxarDadosOlt