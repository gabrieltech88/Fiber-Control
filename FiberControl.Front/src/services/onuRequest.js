async function onuRequest(nome, descricao) {
    const response = await fetch("https://localhost:7155/api/olt/status", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            nome,
            descricao
        })
    })

    const data = await response.json();
    console.log(data.status)
    
    if(data.status !== "offline")
    {
        return true
    }

    return false;
}

export default onuRequest 