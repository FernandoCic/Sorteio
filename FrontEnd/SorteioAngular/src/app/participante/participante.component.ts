import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Participante } from "../models/participante";
import { ParticipantesService } from "../service/participante.service";



@Component({
    selector: 'app-participante',
    templateUrl: './participante.component.html',
    styleUrls: ['./participante.component.scss']
})

export class ParticipanteComponent implements OnInit {
    
    constructor(private router: Router,private participantesService: ParticipantesService) {}
    displayedColumns: string[] = ['cpf', 'nome'];
    idosos: Participante[];
    deficientesFisico: Participante[];
    gerais: Participante[];

    ngOnInit(){
        this.obterParticipantesIdosos();
        this.obterParticipantesComDeficienciaFisica();
        this.obterParticipantesGeral();
    }

    obterParticipantesIdosos(){
        this.participantesService.obterParticipantesIdosos()
                    .subscribe(res => {
                        this.idosos = res;
                    })
    }

    obterParticipantesComDeficienciaFisica(){
        this.participantesService.obterParticipantesComDeficienciaFisica()
                    .subscribe(res => {
                        this.deficientesFisico = res;
                    })
    }

    obterParticipantesGeral(){
        this.participantesService.obterParticipantesGeral()
                    .subscribe(res => {
                        this.gerais = res;
                    })
    }

    realizarSorteio(){
        this.participantesService.realizarSorteio()
    .subscribe(res => {
    });
    this.router.navigate(['/participante-sorteados']);
    }
}