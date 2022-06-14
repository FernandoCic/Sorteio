import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParticipanteSorteadosComponent } from './participante-sorteados/participante-sorteados.component';
import { ParticipanteComponent } from './participante/participante.component';

const routes: Routes = [
  {
    path: 'participante',
    component: ParticipanteComponent,
    data: { title: 'Lista de participantes' }
  },
  {
    path: 'participante-sorteados',
    component: ParticipanteSorteadosComponent,
    data: { title: 'Lista de participantes Sorteados' }
  },
  { path: '',
    redirectTo: '/participante',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
