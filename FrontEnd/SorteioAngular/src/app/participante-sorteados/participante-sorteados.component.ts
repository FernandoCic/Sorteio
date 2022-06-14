import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Participante } from "../models/participante";
import { ParticipantesService } from "../service/participante.service";


@Component({
    selector: 'app-participante-sorteados',
    templateUrl: './participante-sorteados.component.html',
    styleUrls: ['./participante-sorteados.component.scss']
})

export class ParticipanteSorteadosComponent implements OnInit {

    constructor(private router: Router,private participantesService: ParticipantesService) {}
    idosos: Participante[];
    deficientesFisico: Participante[];
    gerais: Participante[];
    participantesSorteados: Participante[];
    displayedColumns: string[] = ['GANHADOR LISTA IDOSO'];
    displayedColumnsDeficiente: string[] = ['GANHADOR LISTA DEFICIENTE FÍSICO'];
    displayedColumnsGeral: string[] = ['GANHADOR LISTA GERAL'];

    ngOnInit(){
        this.SortearGanhadores();
    }

    SortearGanhadores(){
        this.participantesService.realizarSorteio()
                    .subscribe(res => {
                        this.participantesSorteados = res;
                        this.idosos = this.participantesSorteados.filter(p => p.cota == "IDOSO");
                        this.deficientesFisico = this.participantesSorteados.filter(p => p.cota == "DEFICIENTE FÍSICO");
                        this.gerais = this.participantesSorteados.filter(p => p.cota == "GERAL");                     
                    });
       
    }
}