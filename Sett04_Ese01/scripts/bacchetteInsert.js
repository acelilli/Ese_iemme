// - Codice
// - Materiale
// - Nucleo
// - Lunghezza
// - Resistenza
// - Nome del mago proprietario
// - Se presente scegliere tra la casata (SELECT)

//Devo caricare le casate disponibili dal Local Storage
    function caricaCasate(){
        // elenco locale => se "casata" non è null allora fai il parse e trasforma in JSON, altrimenti stringa errore
    let elencoLocal = localStorage.getItem("casata") != null ? JSON.parse(localStorage.getItem("casata")) : [];
    // contenitore casata è una stringa vuota
    let contenitoreCasata = "";
    //per ciascuna entry nell'elenco locale => stampo nella select le casate
    for(let [i, item] of elencoLocal.entries()){
        contenitoreCasata += `
        <option value="${item.nome}">${i + 1}. ${item.nome}</option>
        `;
    }
    // all'interno del menu a tendina metto la stringa de continitoreCasata
    document.getElementById("input-cas").innerHTML = contenitoreCasata;
}

function aggiungiBacchetta() {
    // elennco locale => se "casata" non è null allora fai il parse e trasforma in JSON, altrimenti crea l'array vuoto
    let elencoLocal = localStorage.getItem("bacchette") != null ? JSON.parse(localStorage.getItem("bacchette")) : [];


    let varFoto = document.getElementById("input-foto").value;
    let varCod = document.getElementById("input-cod").value;
    let varMat = document.getElementById("input-mat").value;
    let varNuc = document.getElementById("input-nuc").value;
    let varLun = document.getElementById("input-lun").value;
    let varRes = document.getElementById("input-res").value;
    let varProp= document.getElementById("input-prop").value;
    let varCas = document.getElementById("input-cas").value;
    
    
    let bac = {
        foto: varFoto,
        codice: varCod,
        materiale : varMat,
        nucleo : varNuc,
        lunghezza: varLun,
        resistenza: varRes,
        proprietario: varProp,
        casata: varCas
    }
    
    //push del nuovo cas nell'elenco locale
    elencoLocal.push(bac);
    localStorage.setItem("bacchette", JSON.stringify(elencoLocal))
    
    //reindirizzamento a casate leneco
    location.href = "bacchetteElenco.html"
    }


caricaCasate()