import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Destinazione } from '../../models/destinazione';
import { DestinazioneServicesService } from '../../services/destinazione-services.service';

@Component({
  selector: 'app-destinazione-lista',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './destinazione-lista.component.html',
  styleUrl: './destinazione-lista.component.css'
})
export class DestinazioneListaComponent {

    elencoDestinazioni : Destinazione[] = [];

  constructor(private service : DestinazioneServicesService) {}

  ngOnInit(){
    this.stampaTabella()
  }

  stampaTabella(){
    this.elencoDestinazioni = this.service.ListaDestinazioni();
  }
}
