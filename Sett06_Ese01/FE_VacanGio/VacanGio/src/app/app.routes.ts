import { Routes } from '@angular/router';
import { DestinazioneListaComponent } from './components/destinazione-lista/destinazione-lista.component';

export const routes: Routes = [
    {path: "", redirectTo: "destinazione/lista", pathMatch: "full"},
    {path: "destinazione/lista", component: DestinazioneListaComponent},
];
