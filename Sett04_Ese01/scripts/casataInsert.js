// Ogni casata è caratterizzata da: 
//             - Nome
//             - Descrizione
//             - Logo (link)
//             - Numero di bacchette presenti -> Parte da 0

function aggiungiCasata() {
// elennco locale => se "casata" non è null allora fai il parse e trasforma in JSON, altrimenti crea l'array vuoto
let elencoLocal = localStorage.getItem("casata") != null ? JSON.parse(localStorage.getItem("casata")) : [];

let varNome = document.getElementById("input-nome").value;
let varDesc = document.getElementById("input-des").value;
let varLogo = document.getElementById("input-logo").value;
let varBac = 0;


let cas = {
    nome: varNome,
    descrizione : varDesc,
    logo : varLogo,
    numBa: varBac,
}

//push del nuovo cas nell'elenco locale
elencoLocal.push(cas);
localStorage.setItem("casata", JSON.stringify(elencoLocal))

//reindirizzamento a casate leneco
location.href = "casateElenco.html"
}