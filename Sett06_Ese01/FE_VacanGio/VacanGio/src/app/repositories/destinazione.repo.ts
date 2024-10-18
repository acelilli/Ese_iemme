import { Injectable } from "@angular/core";
import { Destinazione } from "../models/destinazione";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class DestinazioneRepo {

    private endpoint : string = "http://localhost:5051/api/destinazioni";

    private elenco: Destinazione[] =  [];

    constructor() {
    }

    GetAll(): Destinazione[] {
        return this.elenco;
    }

    FetchAll(){

      // http.get<Config>(this.endpoint).subscribe(config => {
      //   // process the configuration.
      // });
    }

    // FetchGetAll(): Promise<Destinazione[]> {
    //     return fetch(this.endpoint)
    //       .then(response => {
    //         if (!response.ok) {
    //           throw new Error('Errore: la response non era ok');
    //         }
    //         return response.json();
    //       })
    //       .then(destinazioni => {
    //         // da fixare
    //         console.log(destinazioni);
    //         this.elenco = destinazioni; 
    //         return this.elenco;
    //       })
    //       .catch(error => {
    //         console.error('Errore Fetch:', error);
    //         throw error;
    //       });
    //   }
}