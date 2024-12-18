function stampaTabella(){
    console.log("Sto stampando una tabella bellissima")
    // elenco locale => se "casata" non è null allora fai il parse e trasforma in JSON, altrimenti crea l'array vuoto
    let elencoLocal = localStorage.getItem("casata") != null ? JSON.parse(localStorage.getItem("casata")) : [];
    // contenitore casata è una stringa vuota
    let contenitoreCasata = "";
    //per ciascuna entry nell'elenco locale => stampo nella tabella ciascun record
    for(let [i, item] of elencoLocal.entries()){
        contenitoreCasata += `
        <tr>
                <td>${i + 1}</td>
                <td>${item.nome}</td>
                <td>${item.descrizione}</td>
                <td>
                <img class="imgTabelle" src="${item.logo}" alt="Logo ${item.nome}">
                </td>
                <td>${item.numBa}</td>
                <td>
                    <button type="button" class="btn btn-elimina" onclick="elimina(${i})">Elimina</button>
                    <button type="button" class="btn btn-warning" onclick="modifica(${i})">Modifica</button>
                </td>
            </tr>
        `;
    }
    // all'interno della taballe casate metto la stringa de continitoreCasata
    document.getElementById("tabella-case").innerHTML = contenitoreCasata;
}



// Funzione pe eliminare le casate
function elimina(indice)
{
    let elencoLocal = localStorage.getItem("casata") != null ? JSON.parse(localStorage.getItem("casata")) : [];
    
    //elimina da un array a partire da un indice(i) quanti elementi(1)
    elencoLocal.splice(indice, 1);

    localStorage.setItem("casata", JSON.stringify(elencoLocal))
    stampaTabella();
}

// Funzione che apre il modale per la modifica
function modifica(indice){
    $("#modaleModifica").modal('show');
    $("#btn-salva").data('identif', indice);

    let elencoLocale = localStorage.getItem("casata") != null 
                            ? JSON.parse(localStorage.getItem("casata")) : [];

    for(let [idx, item] of elencoLocale.entries()){
        if(indice == idx){

            document.getElementById("input-nome").value = item.nome;
            document.getElementById("input-des").value = item.descrizione;
            document.getElementById("input-logo").value = item.logo;
        }
    }
}

function salvaCas(varBtn){
    let posizione = $(varBtn).data('identif')
    let varNome = document.getElementById("input-nome").value;
    let varDesc = document.getElementById("input-des").value;
    let varLogo = document.getElementById("input-logo").value;

    let elencoLocal = localStorage.getItem("casata") != null 
                            ? JSON.parse(localStorage.getItem("casata")) : [];
    for(let [i, item] of elencoLocal.entries()){
        if(i == posizione){
                        
        item.nome = varNome;
        item.descrizione = varDesc;
        item.logo = varLogo;

        localStorage.setItem("casata", JSON.stringify(elencoLocal));
    stampaTabella();
    $("#modaleModifica").modal('hide');
    return;
        }
    }
}

// Contatore delle bacchette per ciascuna casata
function bacchettaPerCasata(){

    //carico le bacchette dal local storage
    let elencoLocalB = localStorage.getItem("bacchette") != null ? JSON.parse(localStorage.getItem("bacchette")) : [];

    //Carico le casate dal local storage
    let elencoLocalC = localStorage.getItem("casata") != null 
                            ? JSON.parse(localStorage.getItem("casata")) : [];

    // Per ciascuna bacchetta controllo a quale casata appartengono e aggiorno item.numBa
    let contatoreBacchette = {}
    // grifondoro = 1++
    
// Contiamo le bacchette per ogni casata
elencoLocalB.forEach(bacchetta => {
    // per ciascuna bacchetta dentro all'elenco bacchette in LocalStorage
    let casata = bacchetta.casata; 
    // crea una variabile in cui casata è uguale a bacchetta.casata
    // se la casata esiste già nell'oggetto contatoreBacchette
    if (contatoreBacchette[casata]) {
        // allora faccio casata++
        contatoreBacchette[casata]++;
    } else {
        // altrimenti sarà = 1
        contatoreBacchette[casata] = 1;
    }
});

// Aggiorniamo gli oggetti delle casate nel local storage
elencoLocalC.forEach(casata => {
    casata.numBa = contatoreBacchette[casata.nome] || 0; 
});

// Modifica le casate nel local storage
localStorage.setItem("casata", JSON.stringify(elencoLocalC));
stampaTabella();
}


stampaTabella();

bacchettaPerCasata()