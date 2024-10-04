function stampaTabella(){
    console.log("Sto stampando una tabella bellissima")
    // elenco locale => se "casata" non è null allora fai il parse e trasforma in JSON, altrimenti crea l'array vuoto
    let elencoLocal = localStorage.getItem("bacchette") != null ? JSON.parse(localStorage.getItem("bacchette")) : [];
    // contenitore casata è una stringa vuota
    let contenitoreBacchetta = "";
    //per ciascuna entry nell'elenco locale => stampo nella tabella ciascun record
    for(let [i, item] of elencoLocal.entries()){
        contenitoreBacchetta += `
        <tr>
                <td>${i + 1}</td>
                <td>
                <img class="imgTabelle" src="${item.foto}" alt="bacchetta ${item.codice}">
                </td>
                <td>${item.codice}</td>
                <td>${item.materiale}</td>
                <td>${item.nucleo}</td>
                <td>${item.lunghezza}</td>
                <td>${item.resistenza}</td>
                <td>${item.proprietario}</td>
                <td>${item.casata}</td>
                <td>
                    <button type="button" class="btn btn-danger" onclick="elimina(${i})">Elimina</button>
                    <button type="button" class="btn btn-warning" onclick="modifica(${i})">Modifica</button>
                </td>
            </tr>
        `;
    }
    // all'interno della taballe casate metto la stringa de continitoreCasata
    document.getElementById("tabella-bac").innerHTML = contenitoreBacchetta;
}



// // Funzione per eliminare le casate
function elimina(indice)
{
    let elencoLocal = localStorage.getItem("bacchette") != null ? JSON.parse(localStorage.getItem("bacchette")) : [];
    
    //elimina da un array a partire da un indice(i) quanti elementi(1)
    elencoLocal.splice(indice, 1);

    localStorage.setItem("bacchette", JSON.stringify(elencoLocal))
    stampaTabella();
}

// Funzione che apre il modale per la modifica
function modifica(indice){
    $("#modaleModifica").modal('show');
    $("#btn-salva").data('identif', indice);

    let elencoLocale = localStorage.getItem("bacchette") != null 
                            ? JSON.parse(localStorage.getItem("bacchette")) : [];

    for(let [idx, item] of elencoLocale.entries()){
        if(indice == idx){
            document.getElementById("input-foto").value = item.foto;
            document.getElementById("input-cod").value = item.codice;
            document.getElementById("input-mat").value = item.materiale;
            document.getElementById("input-nuc").value = item.nucleo;
            document.getElementById("input-lun").value = item.lunghezza;
            document.getElementById("input-res").value = item.resistenza;
            document.getElementById("input-prop").value = item.proprietario;
            document.getElementById("input-cas").value = item.casata;
        }
    }
}

function salvaBac(varBtn){
    let posizione = $(varBtn).data('identif')
    let varFoto = document.getElementById("input-foto").value;
    let varCod = document.getElementById("input-cod").value;
    let varMat = document.getElementById("input-mat").value;
    let varNuc = document.getElementById("input-nuc").value;
    let varLun = document.getElementById("input-lun").value;
    let varRes = document.getElementById("input-res").value;
    let varProp= document.getElementById("input-prop").value;
    let varCas = document.getElementById("input-cas").value;

    let elencoLocal = localStorage.getItem("bacchette") != null 
                            ? JSON.parse(localStorage.getItem("bacchette")) : [];
    for(let [i, item] of elencoLocal.entries()){
        if(i == posizione){
                        
            item.foto = varFoto
            item.codice = varCod
            item.materiale = varMat
            item.nucleo = varNuc
            item.lunghezza = varLun
            item.resistenza = varRes
            item.proprietario = varProp
            item.casata = varCas

        localStorage.setItem("bacchette", JSON.stringify(elencoLocal));
    stampaTabella();
    $("#modaleModifica").modal('hide');
    return;
        }
    }
}

stampaTabella();