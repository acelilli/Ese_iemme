import { Injectable } from "@angular/core";
import { Destinazione } from "../models/destinazione";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class DestinazioneRepo {

    private endpoint : string = "http://localhost:5051/api/destinazioni";

    private elencoDestinazioni: Destinazione[] =  [];

    constructor() {
    }

    GetAll(): Destinazione[] {

        fetch(this.endpoint, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            console.log(data)
            data.forEach((element: Destinazione) => {
                this.elencoDestinazioni.push(element);
            });
        })
        .then(data => console.log(data))
        .catch(error => {
            console.error("Errore nel fetch:", error);
        });
    
        return this.elencoDestinazioni;
    }

}