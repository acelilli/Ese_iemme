import { Injectable } from '@angular/core';
import { DestinazioneRepo } from '../repositories/destinazione.repo';
import { Destinazione } from '../models/destinazione';

@Injectable({
  providedIn: 'root'
})
export class DestinazioneServicesService {

  constructor(private repo: DestinazioneRepo) { }

  ListaDestinazioni(): Destinazione[]{
    return this.repo.GetAll();
  }
}
