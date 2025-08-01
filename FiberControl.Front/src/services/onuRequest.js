async function onuRequest(descricao) {
    const response = await fetch("https://localhost:7155/olt/status", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            olt,
            descricao
        })
    })

    const data = await response.json();
    
    if(!response.ok)
    {
        return true
    }

    return false;
}

export default puxarDadosOlt 